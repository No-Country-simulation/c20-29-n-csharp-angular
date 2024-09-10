import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProductFormComponent } from './components/product-form/product-form.component';
import { SuccessfulComponent } from './components/successful/successful.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { PerfilUserComponent } from './components/perfil-user/perfil-user.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, PerfilUserComponent,NavBarComponent,SuccessfulComponent,ProductFormComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'insta-patitas-front';
}
