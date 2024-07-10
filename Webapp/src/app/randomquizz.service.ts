import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RandomquizzService {
  private apiUrl = 'http://localhost:5001/quizz'; 

  constructor(private http: HttpClient) {}

  getQuizz(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
  createQuizz(quiz: any): Observable<any> {
    return this.http.post(this.apiUrl, quiz);
  }
}
