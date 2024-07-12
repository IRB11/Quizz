import { Component, OnInit } from '@angular/core';
import { Candidat } from './candidat.model';
import { CandidatService } from '../candidat.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-candidat',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './candidat.component.html',
  styleUrl: './candidat.component.css'
})
/*
export class CandidatComponent implements OnInit {

  users!: Candidat[];
  newUser!: Candidat;
  editingUser!: Candidat | null;
  nextUserId!: number;

  ngOnInit() {
    this.loadUsers();
    this.users = [
      new Candidat(1, 'Ibrahim', 'Doe', 'john.doe@example.com'),
      new Candidat(2, 'Natalia', 'Angular', 'jane.doe@example.com'),
      new Candidat(3, 'Test', 'Imovic', 'ibra.imo@example.com'),
    ];

    this.newUser = new Candidat(0, '', '', '');
    this.editingUser = null;
    this.nextUserId = this.users.length > 0 ? Math.max(...this.users.map(u => u.id)) + 1 : 1;
  }

  loadUsers() {
    const storedUsers = localStorage.getItem('users');

    if (storedUsers) {
      this.users = JSON.parse(storedUsers).map(
        (user: any) => new Candidat(user.id, user.firstName, user.lastName, user.email)
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
    this.newUser = new Candidat(0, '', '', '');

    // Incrémentez le compteur d'ID
    this.nextUserId++;
    this.saveUsers();
  }

  updateUser(user: Candidat) {
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

*/



export class CandidatComponent implements OnInit {

  candidats: Candidat[] = [];
  newCandidat: Candidat = {
    id: 0,
    firstName: '',
    lastName: '',
    email: ''
  };

  constructor(private candidatService: CandidatService) { }

  ngOnInit(): void {
    this.getCandidats();
    // Ajouter un candidat fictif pour vérifier la liste
    const candidatFictif: Candidat = {
      id: 1,
      firstName: 'Candide',
      lastName: 'John',
      email: 'john.candidat@example.com',
    };
    this.candidats.push(candidatFictif);
  }

  getCandidats(): void {
    this.candidatService.getCandidats().subscribe((data: Candidat[]) => {
      this.candidats = data;
    });
  }

  addCandidat(newCandidat: Candidat): void {
    this.candidatService.createCandidat(newCandidat).subscribe((candidat: Candidat) => {
      this.candidats.push(candidat);
      this.resetNewCandidat();
    });
  }

  onSubmit(form: NgForm): void {
    if (form.valid) {
      this.addCandidat(this.newCandidat);
    }
  }

  updateCandidat(candidat: Candidat): void {
    this.candidatService.updateCandidat(candidat.id, candidat).subscribe(() => {
      this.getCandidats(); // Recharger la liste après mise à jour
    });
  }

  deleteCandidat(id: number): void {
    this.candidatService.deleteCandidat(id).subscribe(() => {
      this.candidats = this.candidats.filter(c => c.id !== id);
    });
  }

  resetNewCandidat(): void {
    this.newCandidat = {
      id: 0,
      firstName: '',
      lastName: '',
      email: '',
    };
  }
}

