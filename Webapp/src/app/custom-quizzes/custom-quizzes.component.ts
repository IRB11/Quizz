import { Component } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-custom-quizzes',
  standalone: true,
  imports: [],
  templateUrl: './custom-quizzes.component.html',
  styleUrl: './custom-quizzes.component.css'
})
export class CustomQuizzesComponent {
 constructor(private router: Router) { }
 goToQuizzBank() {
   this.router.navigate(['/quizzBank']);
 }
}
