import { Component, OnInit } from '@angular/core';
import { Agent } from './agent.model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-crud',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './agent-crud.component.html',
  styles: ``
})
export class AgentCrudComponent implements OnInit {
  
  users!: Agent[];
  newUser!: Agent;
  editingUser!: Agent | null;
  nextUserId!: number;

  ngOnInit() {
    this.loadUsers();
    this.users = [
      new Agent(1, 'John', 'Doe', 'john.doe@example.com'),
      new Agent(2, 'Jane', 'Doe', 'jane.doe@example.com'),
      new Agent(3, 'Ibra', 'Imovic', 'ibra.imo@example.com'),
    ];

    this.newUser = new Agent(0, '', '', '');
    this.editingUser = null;
    this.nextUserId = this.users.length > 0 ? Math.max(...this.users.map(u => u.id)) + 1 : 1;
  }

  loadUsers() {
    const storedUsers = localStorage.getItem('users');

    if (storedUsers) {
      this.users = JSON.parse(storedUsers).map(
        (user: any) => new Agent(user.id, user.firstName, user.lastName, user.email)
      );

      // Trouvez le prochain ID disponible en fonction des utilisateurs existants
      this.nextUserId = this.users.length > 0 ? Math.max(...this.users.map(u => u.id)) + 1 : 1;
    } else {
      this.users = [];
      this.nextUserId = 1;
    }
  }

  addUser() {
    // Attribuez le prochain ID disponible au nouvel utilisateur
    this.newUser.id = this.nextUserId;

    this.users.push(this.newUser);
    this.newUser = new Agent(0, '', '', '');

    // Incrémentez le compteur d'ID
    this.nextUserId++;
    this.saveUsers();
  }

  updateUser(user: Agent) {
    this.editingUser = user;
  }

  saveUserChanges() {
    if (this.editingUser) {
      // Recherchez l'index de l'utilisateur en cours de modification
      const index = this.users.findIndex(u => u.id === this.editingUser?.id);

      // Mettez à jour l'utilisateur dans le tableau
      this.users[index] = this.editingUser;

      // Réinitialisez l'utilisateur en cours de modification
      this.editingUser = null;

      this.saveUsers();
    }
  }

  deleteUser(userId: number) {
    this.users = this.users.filter(user => user.id !== userId);
    this.saveUsers();
  }
  saveUsers() {
    localStorage.setItem('users', JSON.stringify(this.users));
  }

   cancelUserChanges() {
    this.editingUser = null;
  }

}
