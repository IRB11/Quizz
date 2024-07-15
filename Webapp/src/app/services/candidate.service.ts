
import { Injectable } from '@angular/core';
import { Candidate } from '../entities/candidate.entity';
import { Observable } from 'rxjs/internal/Observable';
import { HttpApiService } from './http-api.service';

@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  constructor(private httpApiService: HttpApiService) { }

  getCandidates(): Observable<Candidate[]> {
    return this.httpApiService.get<Candidate[]>('candidate');
  }
}
