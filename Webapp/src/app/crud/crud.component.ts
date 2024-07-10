import { NgFor, NgIf } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-crud',
  standalone: true,
  imports: [NgIf, NgFor],
  templateUrl: './crud.component.html',
  styleUrl: './crud.component.css'
})
export class CrudComponent {
@Input() type!: string;
@Input() fields!: string[];

}
