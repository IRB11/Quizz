import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ShortcutsComponent } from './shortcuts/shortcuts.component';
import { FormsModule } from '@angular/forms';
import GestionquizzComponent from './gestionquizz/gestionquizz.component';
import { HeaderComponent } from './header/header.component';
import  ResultsComponent from './results/results.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, FooterComponent, HeaderComponent, NavbarComponent, ShortcutsComponent, GestionquizzComponent, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Webapp';
}
