import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', pathMatch: 'full', redirectTo: 'home' },
    { path: 'home', loadComponent: () => import('../app/login-page/login-page.component').then(m => m.LoginPageComponent) },
   // { path: 'about', loadChildren: () => import('./about/about.module').then(m => m.AboutModule) },
    { path: '**', pathMatch: 'full', redirectTo: 'home' },   
]
