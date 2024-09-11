import { Routes } from '@angular/router';

export const routes: Routes = [
  { 
    path: 'login', 
    loadComponent: () => import('./auth/login/login.component').then(m => m.LoginComponent) 
  },
  { 
    path: 'register', 
    loadComponent: () => import('./auth/register/register.component').then(m => m.RegisterComponent) 
  },
  { 
    path: 'modal', 
    loadComponent: () => import('./components/modal-post/modal-post.component').then(m => m.ModalComponent) 
  },
  { 
    path: '**', 
    redirectTo: '/login' 
  }
];
