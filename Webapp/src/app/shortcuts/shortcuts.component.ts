import { NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';

interface Shortcut {
  name: string;
  link: string;
  description?: string; // Description du lien
  iconUrl: string; // URL de l'image de l'icône
  genererquizz?: boolean;
  agentmanager?: boolean;
  planning?: boolean;
  quizzbank?: boolean;
  candidats?: boolean;
  results?: boolean;
  agentmanagement?: boolean;
}

@Component({
  selector: 'app-shortcuts',
  standalone: true,
  imports: [NgFor],
  templateUrl: './shortcuts.component.html',
  styleUrls: ['./shortcuts.component.css']
})
export class ShortcutsComponent {
  shortcuts: Shortcut[] = [
    { name: 'Gestion Agents', link: '/agents', iconUrl: '../../assets/img/iconresults.png', description: 'Gérer les agents'},
    { name: 'Gestion Candidats', link: '/candidats', iconUrl: '../../assets/img/iconcandidats.png', description: 'Gérer les candidats'},
    { name: 'Quizz Bank', link: '/quizzBank', iconUrl: '../../assets/img/iconquizzbank.png', description: 'Quizz Bank' },
    { name: 'Gestion Quizz', link: '/quizz', iconUrl: '../../assets/img/icongenererquizz.png', description: 'Générer quizz' },
    { name: 'Resultats', link: '/results', iconUrl: '../../assets/img/iconresults.png', description: 'Générer résultats' },
    { name: 'Planning', link: '/planning', iconUrl: '../../assets/img/iconplanning.png', description: 'Agenda' }
  ];

}

