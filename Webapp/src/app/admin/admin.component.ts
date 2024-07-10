import { Component } from '@angular/core';
import { NgFor } from '@angular/common';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [NgFor],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent {
  technologies: string[] = [".Net","Angular","Azure DevOps"];
  levels: string [] = ["Junior","Intermédiaire","Confirmé"];
  

}
