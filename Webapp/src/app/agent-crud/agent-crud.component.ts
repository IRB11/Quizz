import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-agent-management',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './agent-crud.component.html',
  styleUrls: ['./agent-crud.component.css']
})
export class AgentCrudComponent implements OnInit {
  searchTerm: string = '';
  editingAgent: any = null;
  newAgent: any = {
    firstName: '',
    lastName: '',
    email: ''
  };
  agents: any[] = [
    { id: 1, firstName: 'John', lastName: 'Doe', email: 'john.doe@example.com' },
    { id: 2, firstName: 'Jane', lastName: 'Smith', email: 'jane.smith@example.com' }
    // Ajoutez vos agents initiaux ici
  ];
  filteredAgents: any[] = [];

  constructor() { }

  ngOnInit(): void {
    // Initialisez filteredAgents avec tous les agents au début
    this.filteredAgents = [...this.agents];
  }

  searchAgents() {
    // Filtrer les agents en fonction de searchTerm
    this.filteredAgents = this.agents.filter(agent =>
      agent.firstName.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      agent.lastName.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      agent.email.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
  }

  editAgent(agent: any) {
    // Afficher le formulaire de modification avec les détails de l'agent sélectionné
    this.editingAgent = { ...agent };
  }

  cancelAgentChanges() {
    // Annuler les modifications en cours
    this.editingAgent = null;
  }

  saveAgentChanges() {
    // Sauvegarder les modifications apportées à l'agent
    // Implémentez la logique pour sauvegarder les changements dans votre service ou backend
    console.log('Modifications sauvegardées pour : ', this.editingAgent);
    this.editingAgent = null;
  }

  addAgent() {
    // Ajouter un nouvel agent à la liste
    // Implémentez la logique pour ajouter un nouvel agent dans votre service ou backend
    this.agents.push(this.newAgent);
    this.filteredAgents = [...this.agents]; // Mettre à jour la liste filtrée
    this.newAgent = { firstName: '', lastName: '', email: '' }; // Réinitialiser le formulaire
  }

  deleteAgent(agentId: number) {
    // Supprimer un agent de la liste
    // Implémentez la logique pour supprimer un agent de votre service ou backend
    this.agents = this.agents.filter(agent => agent.id !== agentId);
    this.filteredAgents = [...this.agents]; // Mettre à jour la liste filtrée
  }
}
