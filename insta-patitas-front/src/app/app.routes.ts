import { Routes } from '@angular/router';
import { ShelterFormComponent } from './components/shelter-form/shelter-form.component';
import { CreatePostComponent } from './components/create-post/create-post.component';

export const routes: Routes = [
  { path: 'shelter-form', component: ShelterFormComponent },
  { path: 'create-post', component: CreatePostComponent },
];
