import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Quizz, Responses, savedResponses } from '../entities/quizz.entity';
import { Question, QuestionId } from '../entities/question.entity';

@Injectable({
  providedIn: 'root'
})
export class HttpApiService {
  delete(endpoint: string, body: any): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}${endpoint}`, body);
  }

  private baseUrl = 'https://localhost:5100/api/'; // Replace with your API base URL

  constructor(private http: HttpClient) {}

  get<T>(endpoint: string): Observable<T> {
    return this.http.get<T>(`${this.baseUrl}${endpoint}`);
  }

  post<T>(endpoint: string, body: any): Observable<T> {
    return this.http.post<T>(`${this.baseUrl}${endpoint}`, body);
  }
  
  put<T>(endpoint: string, body: any): Observable<T> {
    return this.http.put<T>(`${this.baseUrl}${endpoint}`, body);
  }
}