import { Component, InjectionToken, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { GenericService } from '../generic.service';
import { Observable } from 'rxjs';
import { User } from '../model/user';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-user',
  standalone: true,
  imports: [CommonModule,RouterLink, FormsModule],
  providers: [ HttpClient, InjectionToken],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent implements OnInit{

  Users$!: Observable<User[]>;
  id = 0; name = ''; mail = '';
  constructor(private service:GenericService<User>){}
  
  ngOnInit(): void {
    this.list();
  }

  add() { 
    this.service.create({ id: 0, name: this.name, mail: this.mail}).subscribe(() => this.list());
  }

  update() { 
    this.service.update({ id: this.id, name: this.name, mail: this.mail }).subscribe(() => this.list());
  }

  delete() { 
    this.service.delete(this.id).subscribe(() => this.list());
  }

  getById() { 
    this.service.getById(this.id).subscribe((p) => {
      this.mail = p.mail;
      this.name = p.name;
    });
  }

  list() { this.Users$ = this.service.get(); }
}
