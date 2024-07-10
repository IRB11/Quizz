import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { InjectionToken } from '@angular/core';


export interface ServiceConfig {
  resourceEndpoint: string;
}

export const SERVICE_CONFIG = new InjectionToken<ServiceConfig>('ServiceConfig');


@Injectable({
  providedIn: 'root'
})
export class GenericService<T> {

  url ='https://localhost:5001';
  

  constructor(private http:HttpClient) { }

  get() { return this.http.get<T[]>(this.url); }
  getById(id: number) { return this.http.get<T>(`${this.url}${id}`); }
  create(body: T) { return this.http.post<number>(this.url, body); }
  update(body: T) { return this.http.put<void>(this.url, body); }
  delete(id: number) { return this.http.delete<void>(`${this.url}${id}`); }
}
