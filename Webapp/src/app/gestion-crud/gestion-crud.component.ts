import { Component } from '@angular/core';
import { CrudComponent } from '../crud/crud.component';

@Component({
  selector: 'app-gestion-crud',
  standalone: true,
  imports: [CrudComponent],
  templateUrl: './gestion-crud.component.html',
  styleUrl: './gestion-crud.component.css'
})
export default class GestionCrudComponent {
  type = 'create';
  
}
