import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { SplashScreenComponent } from './components/splash-screen/splash-screen.component';
import { SplashGuard } from './components/splash-screen/splash.guard';
import { ModalComponent } from './components/modal-post/modal-post.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent, canActivate: [SplashGuard] },
  { path: 'register', component: RegisterComponent },
  { path: 'splash', component: SplashScreenComponent },
  { path: '', redirectTo: '/splash', pathMatch: 'full' },
  { path: 'modal', component: ModalComponent }, 
  { path: '**', redirectTo: '/login' }
];
