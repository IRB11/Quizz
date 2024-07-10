import { NgFor, NgIf } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule, NgModel } from '@angular/forms';
import { Router } from '@angular/router';
import { RandomquizzService } from '../randomquizz.service';

interface Question {
  question: string;
  answer: string;
}

@Component({
  selector: 'app-generatequizz',
  standalone: true,
  providers: [RandomquizzService],
  imports: [NgFor, FormsModule, NgIf],
  templateUrl: './generatequizz.component.html',
  styleUrl: './generatequizz.component.css'
})
export default class GeneratequizzComponent {
  technologies: string[] = ['Angular', 'DotNET', 'DevOps', 'C#'];
  levels: string[] = ['Junior', 'Middle', 'Senior'];
  questions: Question[] = [];

  #quizzService = inject(RandomquizzService);
  #router = inject(Router);

  candidates = [
    { name: 'Alice', email: 'alice@example.com' },
    { name: 'Bob', email: 'bob@example.com' },
    { name: 'Charlie', email: 'charlie@example.com' }
  ];

  agents = [
    { name: 'Alice', email: 'alice@example.com' },
    { name: 'Bob', email: 'bob@example.com' },
    { name: 'Charlie', email: 'charlie@example.com' }
  ];
  errorMessage: string = '';
  questioncount = undefined as unknown as number;

  selectedTechnology: string = this.technologies[0];
  selectedLevel: string = this.levels[0];
  quizName: string = '';
  selectedCandidate: string = this.candidates[0].email;
  selectedAgent: string = this.agents[0].email;
  questionCount: number = this.questioncount;
  quizUrl: string = '';

  generateQuiz() {
    if (this.quizName.trim() === '') {
      alert('Enter le titre du quizz');
      return;
    }

    if (this.questionCount !== null && (this.questionCount < 5 || this.questionCount > 40)) {
      this.errorMessage = 'Le nombre compris entre 5 et 40';
      return false;
    } else {
      this.errorMessage = '';
      return true;
    }
    // Logique pour générer le quiz
    alert(`Quiz "${this.quizName}" pour ${this.selectedTechnology} au niveau ${this.selectedLevel} généré !`);
    
    const quizz = {
      technology: this.selectedTechnology,
      level: this.selectedLevel,
      name: this.quizName,
      questionCount: this.questionCount
    };
    this.#quizzService.createQuizz(quizz).subscribe(
      
    );
    this.quizUrl = `https://example.com/quiz?name=${encodeURIComponent(this.quizName)}&tech=${encodeURIComponent(this.selectedTechnology)}&level=${encodeURIComponent(this.selectedLevel)}`;
  }

  getQuizUrl() {
    if (this.quizUrl === '') {
      alert('Veuillez d\'abord générer le quizz');
    } else {
      alert(`URL du quizz: ${this.quizUrl}`);
    }
  }

  generateAndSendQuiz() {
    this.generateQuiz();
    if (this.quizUrl !== '') {
      const subject = encodeURIComponent('Votre quiz technique');
      const body = encodeURIComponent(`Bonjour futur recru,\n\nÀ toi de montrer à quoi tu es capable! : ${this.quizUrl}\n\nBonne chance !`);
      const mailtoLink = `mailto:${this.selectedCandidate}?subject=${subject}&body=${body}`;
      window.open(mailtoLink, '_blank');
    }
  }
}
