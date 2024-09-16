import { Component, OnInit } from '@angular/core';
import { img } from '../../mock/img.mock';
import { NavBarComponent } from '../nav-bar/nav-bar.component';

@Component({
  selector: 'app-perfil-user',
  standalone: true,
  imports: [NavBarComponent],
  templateUrl: './perfil-user.component.html',
  styleUrl: './perfil-user.component.css'
})
export class PerfilUserComponent implements OnInit{
  img: string[] = img;


  ngOnInit(): void {
    
  }
}
