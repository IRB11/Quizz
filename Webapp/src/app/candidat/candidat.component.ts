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

export class CandidatComponent implements OnInit {
  searchTerm: string = '';
  editingCandidate: any = null;
  newCandidate: any = {
    firstName: '',
    lastName: '',
    email: ''
  };
  candidates: any[] = [
    { id: 1, firstName: 'Alice', lastName: 'Johnson', email: 'alice.johnson@example.com', testResults: '85%' },
    { id: 2, firstName: 'Bob', lastName: 'Smith', email: 'bob.smith@example.com', testResults: '90%' }
    // Ajoutez vos candidats initiaux ici
  ];
  filteredCandidates: any[] = [];

  constructor() { }

  ngOnInit(): void {
    // Initialisez filteredCandidates avec tous les candidats au début
    this.filteredCandidates = [...this.candidates];
  }

  searchCandidates() {
    // Filtrer les candidats en fonction de searchTerm
    this.filteredCandidates = this.candidates.filter(candidate =>
      candidate.firstName.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      candidate.lastName.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      candidate.email.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  editCandidate(candidate: any) {
    // Afficher le formulaire de modification avec les détails du candidat sélectionné
    this.editingCandidate = { ...candidate };
  }

  cancelCandidateChanges() {
    // Annuler les modifications en cours
    this.editingCandidate = null;
  }

  saveCandidateChanges() {
    // Sauvegarder les modifications apportées au candidat
    // Implémentez la logique pour sauvegarder les changements dans votre service ou backend
    console.log('Modifications sauvegardées pour : ', this.editingCandidate);
    this.editingCandidate = null;
  }

  addCandidate() {
    // Ajouter un nouveau candidat à la liste
    // Implémentez la logique pour ajouter un nouveau candidat dans votre service ou backend
    this.candidates.push({ ...this.newCandidate, id: this.candidates.length + 1 });
    this.filteredCandidates = [...this.candidates]; // Mettre à jour la liste filtrée
    this.newCandidate = { firstName: '', lastName: '', email: '' }; // Réinitialiser le formulaire
  }

  deleteCandidate(candidateId: number) {
    // Supprimer un candidat de la liste
    // Implémentez la logique pour supprimer un candidat de votre service ou backend
    this.candidates = this.candidates.filter(candidate => candidate.id !== candidateId);
    this.filteredCandidates = [...this.candidates]; // Mettre à jour la liste filtrée
  }

  contactCandidate(email: string) {
    // Logique pour contacter le candidat
    console.log('Contacter le candidat à : ', email);
    // Vous pouvez ouvrir un client de messagerie ou utiliser une autre méthode pour contacter le candidat
  }
}

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
} */
