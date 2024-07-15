import { Component, OnInit, inject } from '@angular/core';
import { QuizzService } from '../quizz.service';
import { NgFor } from '@angular/common';
import { Quizz } from '../entities/quizz.entity';

@Component({
  selector: 'app-quizz-list',
  standalone: true,
  imports: [NgFor],
  templateUrl: './quizz-list.component.html',
  styleUrls: ['./quizz-list.component.css']
})
export class QuizzListComponent implements OnInit {
  quizzList: any[] = [];

  private quizzService = inject(QuizzService);

  constructor() {}

  ngOnInit() {
    this.quizzService.getQuizzes().subscribe(
      (response: any) => {
        if (response && Array.isArray(response.result)) {
          this.quizzList = response.result.map((quizz: { id: any; comment: any; completionLevel: any; completionTime: any; isValid: any; numberOfQuestion: any; quizzNumber: any; result: any; url: any; agent: { id: any; firstName: any; lastName: any; emailAddress: any; phoneNumber: any; isActive: any; token: any; role: any; }; admin: { id: any; firstName: any; lastName: any; emailAddress: any; phoneNumber: any; isActive: any; token: any; role: any; }; candidate: { id: any; firstName: any; lastname: any; phoneNumber: any; emailAdress: any; agentId: any; agent: { id: any; firstName: any; lastName: any; emailAddress: any; phoneNumber: any; isActive: any; token: any; role: any; }; quiz: any; }; statusId: any; status: { id: any; status: any; }; level: any; technologies: { id: any; name: any; }; }) => ({
            id: quizz.id,
            comment: quizz.comment,
            completionLevel: quizz.completionLevel,
            completionTime: quizz.completionTime,
            isValid: quizz.isValid,
            numberOfQuestion: quizz.numberOfQuestion,
            quizzNumber: quizz.quizzNumber,
            result: quizz.result,
            url: quizz.url,
            agent: {
              id: quizz.agent.id,
              firstName: quizz.agent.firstName,
              lastName: quizz.agent.lastName,
              emailAddress: quizz.agent.emailAddress,
              phoneNumber: quizz.agent.phoneNumber,
              isActive: quizz.agent.isActive,
              token: quizz.agent.token,
              role: quizz.agent.role
            },
            admin: {
              id: quizz.admin.id,
              firstName: quizz.admin.firstName,
              lastName: quizz.admin.lastName,
              emailAddress: quizz.admin.emailAddress,
              phoneNumber: quizz.admin.phoneNumber,
              isActive: quizz.admin.isActive,
              token: quizz.admin.token,
              role: quizz.admin.role
            },
            candidate: {
              id: quizz.candidate.id,
              firstName: quizz.candidate.firstName,
              lastname: quizz.candidate.lastname,
              phoneNumber: quizz.candidate.phoneNumber,
              emailAdress: quizz.candidate.emailAdress,
              agentId: quizz.candidate.agentId,
              agent: {
                id: quizz.candidate.agent.id,
                firstName: quizz.candidate.agent.firstName,
                lastName: quizz.candidate.agent.lastName,
                emailAddress: quizz.candidate.agent.emailAddress,
                phoneNumber: quizz.candidate.agent.phoneNumber,
                isActive: quizz.candidate.agent.isActive,
                token: quizz.candidate.agent.token,
                role: quizz.candidate.agent.role
              },
              quiz: quizz.candidate.quiz
            },
            statusId: quizz.statusId,
            status: {
              id: quizz.status.id,
              status: quizz.status.status
            },
            level: quizz.level,
            technologies: {
              id: quizz.technologies.id,
              name: quizz.technologies.name
            }
          }));
        } else {
          console.error('Error: Expected an array of quizzes but received:', response);
        }
      },
      (error: any) => {
        console.error('Error fetching quizzes:', error);
      }
    );
  }
  }

