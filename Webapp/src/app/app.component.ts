import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ShortcutsComponent } from './shortcuts/shortcuts.component';
import { FormsModule } from '@angular/forms';
import GestionquizzComponent from './gestionquizz/gestionquizz.component';
import { HeaderComponent } from './header/header.component';
import  ResultsComponent from './results/results.component';
import { HttpClient } from '@angular/common/http';
import { GenericService } from './generic.service';
import { CandidatComponent } from './candidat/candidat.component';
import { QuizzBankComponent } from './quizz-bank/quizz-bank.component';
import { QuizzBankService } from './quizz-bank.service';  
import { RandomquizzService } from './randomquizz.service';
import { NgIf } from '@angular/common';


@Component({
  selector: 'app-root',
  standalone: true,
    imports: [RouterOutlet, FooterComponent, HeaderComponent, NavbarComponent, ShortcutsComponent, GestionquizzComponent, FormsModule, CandidatComponent, NgIf],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  isQuizDetailPage() {
    const currentUrl = window.location.href;
    const isQuizzPage = currentUrl.includes('/quizz/') && /\d/.test(currentUrl);
    return currentUrl.includes('/quizz/') && /\d/.test(currentUrl);
  }
    title = 'Webapp';
}
