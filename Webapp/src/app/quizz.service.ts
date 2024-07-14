import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpApiService } from './services/http-api.service';
import { Quizz, Responses, savedResponses } from './entities/quizz.entity';
import { Question, QuestionId } from './entities/question.entity';

@Injectable({
  providedIn: 'root'
})
export class QuizzService {


  private quizSource = new BehaviorSubject<Quizz | null>(null);
  quiz$ = this.quizSource.asObservable();
  constructor(private httpApiService: HttpApiService) {}

  createQuizz(quizz: Quizz): Observable<any>{
    return this.httpApiService.post(`quizz`, quizz);
  }
  getQuizzes(): Observable<any> {
    return this.httpApiService.get(`quizz`); // Assuming 0 returns all quizzes
  }
  getQuizz(id: number): Observable<Quizz> {
    return this.httpApiService.get(`quizz/${id}`);
  }
  getQuestions(questionId: number): Observable<Question> {
    return this.httpApiService.get(`question/${questionId}`);
  }
  deleteQuestion(questionId: number, question: Question ): Observable<Question> {
    return this.httpApiService.delete(`question/${questionId}`, question);
  }
  getQuizzQuestionIds(quizzId: number): Observable<QuestionId[]>  {
    return this.httpApiService.get(`question/questions/${quizzId}`);
  }
  postQuizzResponse(savedResponses: savedResponses[]): Observable<any> {
    return this.httpApiService.post(`Question/Save`, savedResponses);
  }
  setQuiz(quiz: Quizz) {
    this.quizSource.next(quiz);
  }
  updateQuizStatus(quizz: Quizz, arg1: number) {
    quizz.statusId = 2;
    quizz.adminId = quizz.admin.id;
    quizz.technologyId = quizz.technology.id;
    quizz.agentId = quizz.agent.id;
    quizz.candidateId = quizz.candidate.id;
    quizz.agent = null;
    quizz.admin = null;
    quizz.technology = null;
    return this.httpApiService.put(`quizz/${quizz.id}`, quizz);
  }
}