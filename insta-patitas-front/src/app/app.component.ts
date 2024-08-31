import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ShelterFormComponent } from './shelter-form/shelter-form.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ShelterFormComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'insta-patitas-front';
  shelteForm = 'shelter-form';
}
