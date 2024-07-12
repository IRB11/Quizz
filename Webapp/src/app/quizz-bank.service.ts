import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Answer, Question } from './model/question';

@Injectable({
  providedIn: 'root'
})
export class QuizzBankService {
  

  private apiUrl = 'http://localhost:5001/questions';
  constructor(private http: HttpClient) { }

  getQuestion(id: number): Observable<Question> {
    return this.http.get<Question>(`${this.apiUrl}/questions/${id}`);
  }
  getQuestions(): Observable<Question[]> {
    return this.http.get<Question[]>(`${this.apiUrl}/questions/`);
  }


  getPastQuizzes(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/past-quizzes`);
  }


  createAnswer(id: number, answer: Answer) : Observable<Answer> {
    return this.http.post<Answer>(`${this.apiUrl}/questions/${id}/answers`, answer);
  }


  createQuestion(question: Question): Observable<Question> {
    return this.http.post<Question>(`${this.apiUrl}/questions`, question);
  }

  updateQuestion(question: Question): Observable<Question> {
    return this.http.put<Question>(`${this.apiUrl}/questions/${question.id}`, question);
  }

  deleteQuestion(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/questions/${id}`);
  }
}
