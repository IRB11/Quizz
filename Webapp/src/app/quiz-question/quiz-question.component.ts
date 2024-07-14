import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { CommonModule } from '@angular/common';
import { QuizzService } from '../quizz.service';
import { Question } from '../entities/question.entity';
import { Quizz, Responses, savedResponses } from '../entities/quizz.entity';

@Component({
  selector: 'app-quizz-question',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './quiz-question.component.html',
})
export class QuizzQuestionComponent {
  quizz!: Quizz | null;
  questions!: Question;
  currentQuestionIndex: number = 0;
  selectedOptions: Responses[] = [];
  savedResponses: savedResponses[] = [];
  showResult: boolean = false;
  isCorrectAnswer: boolean = false;
  quizFinished: boolean = false;
  questionIds : any[] = [];
  quizzId = Number(this.route.snapshot.paramMap.get('id'));
  constructor(private route: ActivatedRoute, private quizzService: QuizzService) {
    this.quizzService.quiz$.subscribe(quiz => {
      this.quizz = quiz;
    });
    this.quizzService.getQuizzQuestionIds(this.quizzId).subscribe((data) => {
      this.questionIds = data;
      console.log(data);
      this.loadQuestion(this.currentQuestionIndex);
    });
  }

  loadQuestion(index: number) {
    this.showResult = false;
    this.isCorrectAnswer = false;
    this.selectedOptions = [];
    this.currentQuestionIndex = index;
    this.quizFinished = false; 

    if (index < this.questionIds.length) {
      const questionId = this.questionIds[index];
      this.quizzService.getQuestions(questionId).subscribe((question: Question) => {
        this.questions = question;
        console.log(this.questions.response);
      });
    } else {
      this.quizFinished = true; // Mark the quiz as finished once all questions have been answered
    }
  }

  selectOption(option: Responses) {
    if (this.selectedOptions.includes(option)) {
      this.selectedOptions = this.selectedOptions.filter(opt => opt !== option);
    } else {
      this.selectedOptions.push(option);
    }
  }

  submitAnswer() {
    this.showResult = true;
    if (this.questions && this.questions.response && this.currentQuestionIndex < this.questionIds.length - 1) {
      this.currentQuestionIndex++;
      this.selectedOptions.forEach(option => {
        this.savedResponses.push({
          content: option.content || '',
          responseId: option.id ?? 0,
          quizId: this.quizzId,
          questionId: this.questions.id,
          openResponseText: '',
          isSkipped: false,
          comment: ''
        });
      });
      this.selectedOptions = [];
      this.quizzService.postQuizzResponse(this.savedResponses).subscribe({
        next: (data: any) => {
          console.log(data);
        },
        error: (err: any) => {
          console.error('Error posting quiz response', err);
        }
      });
      this.savedResponses = [];
      this.loadQuestion(this.currentQuestionIndex);
    } else {
      this.quizFinished = true;
      if (this.quizz) {
        this.quizzService.updateQuizStatus(this.quizz, 2).subscribe({
          next: (data: any) => {
            console.log('Quiz status updated to 2');
          },
          error: (err: any) => {
            console.error('Error updating quiz status', err);
          }
        });
      }
    }
  }
  ngOnInit() {
    this.quizzService.quiz$.subscribe(quiz => {
      this.quizz = quiz;
    });
}
}
