import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import {jsPDF} from 'jspdf';
import autoTable from 'jspdf-autotable'; // Added this line



@Component({
  selector: 'app-results',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './results.component.html',
  styleUrl: './results.component.css'
})
export default class ResultsComponent implements OnInit {
  candidateNameOrUrl: string = '';
  quizResults: any = null;
  isLoading: boolean = true;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.isLoading = true;
    this.http.get('http://localhost:5001/quizResults').subscribe({
      next: (data: any) => {
        this.quizResults = data;
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Erreur lors de la récupération des résultats du quiz:', error);
        this.isLoading = false;
      }
    });
  }

  loadPDF(): void {
        if (this.quizResults != null) {
          const doc = new jsPDF();
          doc.text('Résultats du quiz', 50, 30);
          const tableData = this.quizResults.map((result: any) => [result.candidateName, result.question, result.answer, result.correctAnswer, result.score, result.quizName]);
          
          autoTable(doc, { // Changed this line
            head: [['Question', 'Réponse', 'Réponse Correcte']],
            body: tableData
          });

          doc.save('results.pdf');
          console.log('Charger le PDF pour:', this.candidateNameOrUrl);
        }
        else {
          console.error('Aucun résultat du quiz trouvé');
        }
    // Ajoutez ici la logique pour générer et charger le PDF en fonction de l'entrée de l'utilisateur
  }
}