import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ShelterFormComponent } from '../../components/shelter-form/shelter-form.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
