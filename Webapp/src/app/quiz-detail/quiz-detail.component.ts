import { Component, inject } from '@angular/core';
import { ActivatedRoute, RouterLink, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpApiService } from '../services/http-api.service';
import { QuizzService } from '../quizz.service';
import { Quizz } from '../entities/quizz.entity';



@Component({
  selector: 'app-quiz-detail',
  standalone: true,
  imports: [CommonModule, RouterModule,RouterLink], // Add HttpClientModule here
  templateUrl: './quiz-detail.component.html',
  providers: [HttpApiService] // Provide HttpApiService if not provided in root
})
export class QuizDetailComponent {
  quizz!: any;
  private route = inject(ActivatedRoute);
  private quizzService = inject(QuizzService); // Inject HttpApiService

  constructor() {
    const quizzId = this.route.snapshot.paramMap.get('id');
    if (quizzId !== null) {
      this.quizzService.getQuizz(Number(quizzId)).subscribe(data => {
        this.quizz = data;
        console.log(this.quizz);
        console.log(this.quizz.numberOfQuestion);
        
      });
    }
  }
  sendQuiz() {   
    this.quizzService.setQuiz(this.quizz);
  }
}