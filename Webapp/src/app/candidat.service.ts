import { Injectable } from '@angular/core';
import { Candidat } from './candidat/candidat.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CandidatService {


  private apiUrl = 'http://localhost:5001/api/candidats'; // Remplacez par l'URL de votre API

  constructor(private http: HttpClient) { }

  // Créer un nouveau candidat
  createCandidat(candidat: Candidat): Observable<Candidat> {
    return this.http.post<Candidat>(this.apiUrl, candidat);
  }

  // Obtenir la liste des candidats
  getCandidats(): Observable<Candidat[]> {
    return this.http.get<Candidat[]>(this.apiUrl);
  }

  // Obtenir un candidat par ID
  getCandidatById(id: number): Observable<Candidat> {
    return this.http.get<Candidat>(`${this.apiUrl}/${id}`);
  }

  // Mettre à jour un candidat
  updateCandidat(id: number, candidat: Candidat): Observable<Candidat> {
    return this.http.put<Candidat>(`${this.apiUrl}/${id}`, candidat);
  }

  // Supprimer un candidat
  deleteCandidat(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}

