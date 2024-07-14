import { Injectable } from '@angular/core';
import { HttpApiService } from './http-api.service';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class TechnologyService {


  constructor(private httpApiService: HttpApiService) {}

  getTechnologies() : Observable<any> {
    return this.httpApiService.get(`Techno`); 
  }
}
