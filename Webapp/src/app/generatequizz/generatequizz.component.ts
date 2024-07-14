import { NgFor, NgIf } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule, NgModel } from '@angular/forms';
import { Router } from '@angular/router';
import { RandomquizzService } from '../randomquizz.service';
import { TechnologyService } from '../services/technology.service';
import { LevelService } from '../services/level.service';
import { Technology } from '../entities/technology.entity';
import { Level } from '../entities/level.entity';
import { Quizz } from '../entities/quizz.entity';
import { Candidate } from '../entities/candidate.entity';
import { CandidateService } from '../services/candidate.service';
import { QuizzService } from '../quizz.service';

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


  #quizzService = inject(QuizzService);
  #router = inject(Router);
  #technologyService = inject(TechnologyService);
  #levelService = inject(LevelService);
  #candidateService = inject(CandidateService);

  technologies: Technology[] = [];
  levels: Level[] = [];
  questions: Question[] = [];
  candidates: Candidate[] = [];

  agents = [
    { id: 1, name: 'Alice', email: 'alice@example.com' },
    { id: 2, name: 'Bob', email: 'bob@example.com' },
    { id: 3, name: 'Charlie', email: 'charlie@example.com' }
  ];
  errorMessage: string = '';
  questioncount = undefined as unknown as number;

  selectedTechnology: string = '';
  selectedLevel: string = '';
  quizName: string = '';
  selectedCandidate?: number;
  selectedAgent: number = this.agents[0].id;
  questionCount: number = this.questioncount;
  quizUrl: string = '';

  constructor() {
    this.loadTechnologies();
    this.loadLevels();
    this.loadCandidates();
  }

  loadTechnologies() {
    this.#technologyService.getTechnologies().subscribe((data: Technology[]) => {
      this.technologies = data;
      this.selectedTechnology = this.technologies.length > 0 ? this.technologies[0].name : '';
    });
  }

  loadLevels() {
    this.#levelService.getLevels().subscribe((data: Level[]) => {
          this.levels = data;
          this.selectedLevel = this.levels.length > 0 ? this.levels[0].content : '';
    });
  }
  loadCandidates() {
    this.#candidateService.getCandidates().subscribe((data: Candidate[]) => {
          this.candidates = data;
          this.selectedCandidate = this.candidates.length > 0 ? this.candidates[0].id : undefined;
    });
  }

  generateQuiz() {
    if (this.quizName.trim() === '') {
      alert('Enter le titre du quizz');
      return;
    }

    if (this.questionCount === undefined || this.questionCount < 5 || this.questionCount > 40) {
      this.errorMessage = 'Le nombre de questions doit être compris entre 5 et 40';
      return;
    } else {
      this.errorMessage = '';
    }
    const quizz: Quizz = {
      id: 0, 
      candidate : null,
      candidateId: this.selectedCandidate ?? 0,
      agent: null,
      agentId: this.selectedAgent,
      technology: null,
      technologyId: this.technologies.find(tech => tech.name === this.selectedTechnology)?.id ?? 0,
      level: this.levels.find(level => level.content === this.selectedLevel) ?? { id: 0, content: '' },
      admin: null,
      adminId: 1, // Assuming adminId is 1 for now
      comment: this.quizName,
      completionLevel: 0,
      completionTime: new Date(),
      isValid: true,
      numberOfQuestion: this.questionCount,
      quizzNumber: '',
      result: 0,
      url: '',
      statusId: 1,
      status: null,
      levelId: this.levels.find(level => level.content === this.selectedLevel)?.id ?? 0,
    };
    console.log(quizz);
    this.#quizzService.createQuizz(quizz).subscribe(
      (response) => {
        this.quizUrl = response.quizUrl;
      },
      (error) => {
        this.errorMessage = 'Erreur lors de la création du quizz';
      }
    );
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
      const mailtoLink = `mailto:${this.candidates.find(candidate => candidate.id === this.selectedCandidate)?.emailAddress}?subject=${subject}&body=${body}`;
      window.open(mailtoLink, '_blank');
    }
  }
}
