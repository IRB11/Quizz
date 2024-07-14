import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { HttpApiService } from './http-api.service';

@Injectable({
  providedIn: 'root'
})
export class LevelService {
  constructor(private httpApiService: HttpApiService) {}

  getLevels() : Observable<any> {
    return this.httpApiService.get(`level`); 
  }
}
