import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
// import {jsPDF} from 'jspdf';
import 'jspdf-autotable';



@Component({
  selector: 'app-results',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './results.component.html',
  styleUrl: './results.component.css'
})
export default class ResultsComponent {
  candidateNameOrUrl: string = '';

  constructor() {}

  loadPDF(): void {
    // Logique pour charger le PDF en fonction de candidateNameOrUrl
    console.log('Charger le PDF pour:', this.candidateNameOrUrl);
    // Ajoutez ici la logique pour générer et charger le PDF en fonction de l'entrée de l'utilisateur
  }
}