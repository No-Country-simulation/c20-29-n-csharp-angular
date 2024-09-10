import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ShelterFormComponent } from './components/shelter-form/shelter-form.component';
import { CreatePostComponent } from './components/create-post/create-post.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    FormsModule,
    ShelterFormComponent,
    CreatePostComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'insta-patitas-front';
}
