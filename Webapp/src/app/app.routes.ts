import { Routes, RouterModule } from '@angular/router';


export const routes: Routes = [
    { path: '', pathMatch: 'full', redirectTo: 'login' },
    { path: 'admin', loadComponent: () => import('../app/admin/admin.component').then(m => m.AdminComponent)},
    { path: 'agents', loadComponent: () => import('./agent-crud/agent-crud.component').then(m => m.AgentCrudComponent)},
    { path: 'quiz', loadComponent: () => import('../app/quiz/quiz.component').then(m => m.QuizComponent)},

    { path: 'login', loadComponent: () => import('../app/login-page/login-page.component').then(m => m.LoginPageComponent) },
    { path: 'home', loadComponent : () => import('../app/home/home.component').then(m => m.HomeComponent) },
    { path: 'quizz', loadComponent: () => import('../app/gestionquizz/gestionquizz.component')},
    { path: 'results', loadComponent: () => import('../app/results/results.component')},
    { path: 'quizzBank', loadComponent: () => import('../app/quizz-bank/quizz-bank.component').then(m=> m.QuizzBankComponent)},
    // Example de shortcut  pour les routes
    // { path: 'le nom de mon link ', loadComponent: () => import('../app/gestionquizz/gestionquizz.component')},
]
