import { Component, OnInit } from '@angular/core';
import { QuizzBankService } from '../quizz-bank.service';
import { Question } from '../model/question';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-quizz-bank',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './quizz-bank.component.html',
  styleUrls: ['./quizz-bank.component.css']
})
export class QuizzBankComponent implements OnInit {

  questions: Question[] = [];
  selectedQuestion: Question = { id: 0, text: '', answers: [{ id: 0, text: '', isCorrect: false }] };
  editQuestionModalOpen = false;

  constructor(private quizzBankService: QuizzBankService) { }

  ngOnInit(): void {
    // Optionally load data on init
    // this.loadQuestions();
    // this.loadPastQuizzes();
  }

  getPastQuizzes(): void {
    // Implement this function to load past quizzes
    this.quizzBankService.getPastQuizzes().subscribe({
      next: (data: any) => console.log(data),
      error: (err: any) => console.error('There was an error!', err)
    });
  }

  getQuestions(): void {
    this.quizzBankService.getQuestions().subscribe({
      next: (data: Question[]) => this.questions = data,
      error: (err: any) => console.error('There was an error!', err)
    });
  }

  addQuestion(): void {
    // Implement this function to add a question
    const newQuestion: Question = { id: 0, text: 'New Question', answers: [] };
    this.quizzBankService.createQuestion(newQuestion).subscribe({
      next: (data: Question) => this.questions.push(data),
      error: (err: any) => console.error('There was an error!', err)
    });
  }

  editQuestion(question: Question): void {
    // Open modal and set selectedQuestion for editing
    this.selectedQuestion = { ...question }; // Make a copy to avoid two-way binding issues
    this.editQuestionModalOpen = true;
  }

  updateQuestion(): void {
    // Implement this function to update the selected question
    if (this.selectedQuestion.id) {
      this.quizzBankService.updateQuestion(this.selectedQuestion).subscribe({
        next: () => {
          this.getQuestions();
          this.editQuestionModalOpen = false;
        },
        error: (err: any) => console.error('There was an error!', err)
      });
    }
  }

  deleteQuestion(id: number | undefined): void {
    if (id) {
      this.quizzBankService.deleteQuestion(id).subscribe({
        next: () => this.getQuestions(),
        error: (err: any) => console.error('There was an error!', err)
      });
    }
  }
}
