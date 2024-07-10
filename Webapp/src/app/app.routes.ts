import { Routes, RouterModule } from '@angular/router';

export const routes: Routes = [
    { path: '', pathMatch: 'full', redirectTo: 'login' },
    { path: 'login', loadComponent: () => import('../app/login-page/login-page.component').then(m => m.LoginPageComponent) },
    { path: 'home', loadComponent : () => import('../app/home/home.component').then(m => m.HomeComponent) },
    { path: 'quizz', loadComponent: () => import('../app/gestionquizz/gestionquizz.component')},
    { path: 'results', loadComponent: () => import('../app/results/results.component')},
    
    // Example de shortcut  pour les routes
    // { path: 'le nom de mon link ', loadComponent: () => import('../app/gestionquizz/gestionquizz.component')},
    { path: '**', pathMatch: 'full', redirectTo: 'home' },   
]
