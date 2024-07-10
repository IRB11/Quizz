import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-quiz',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.css']
})

export class QuizComponent  {
  /*
  public questionsSubject = new BehaviorSubject<any[]>([]);

  constructor(private http: HttpClient) {
    this.loadQuestions();
  }

  private loadQuestions() {
    this.http.get<any[]>('../../../assets/questions.json').subscribe(
      questions => this.questionsSubject.next(questions),
      error => console.error('Error loading questions:', error)
    );
  }

  question$ = this.questionsSubject.asObservable();
  currentQuestionIndex = 0;
  */
  public questionsSubject = new BehaviorSubject<any[]>([
    {
      question: "Quelle est la capitale de la France ?",
      options: ["Paris", "Londres", "Berlin", "Madrid"],
      answer: "Paris",
      difficulty: "Facile",
      technology: "Géographie"
    },
    {
      question: "Quelle est la valeur de PI ?",
      options: ["3.14", "2.71", "1.62", "1.41"],
      answer: "3.14",
      difficulty: "Facile",
      technology: "Mathématiques"
    },
    {
      question: "Que veut dire API ?",
      options: ["Application Programming Interface", "Acces Parallel Interface"],
      answer: "Application Programming Interface",
      difficulty: "Intermédiaire",
      technology: "C#"
    }
  ]);

  questions$ = this.questionsSubject.asObservable();
  currentQuestionIndex = 0;

  get currentQuestion() {
    return this.questionsSubject.value[this.currentQuestionIndex];
  }

  nextQuestion() {
    if (this.currentQuestionIndex < this.questionsSubject.value.length - 1) {
      this.currentQuestionIndex++;
    }
  }

  previousQuestion() {
    if (this.currentQuestionIndex > 0) {
      this.currentQuestionIndex--;
    }
  }

}