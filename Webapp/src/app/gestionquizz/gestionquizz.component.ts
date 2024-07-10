import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import GeneratequizzComponent from '../generatequizz/generatequizz.component';
import { CustomQuizzesComponent } from '../custom-quizzes/custom-quizzes.component';
import ResultsComponent from '../results/results.component';

@Component({
  selector: 'app-gestionquizz',
  standalone: true,
  imports: [GeneratequizzComponent,CustomQuizzesComponent,ResultsComponent],
  templateUrl: './gestionquizz.component.html',
  styleUrl: './gestionquizz.component.css'
})
export default class GestionquizzComponent {

}
