import { Component, OnInit } from '@angular/core';
import { img } from '../../mock/img.mock';

@Component({
  selector: 'app-perfil-user',
  standalone: true,
  imports: [],
  templateUrl: './perfil-user.component.html',
  styleUrl: './perfil-user.component.css'
})
export class PerfilUserComponent implements OnInit{
  img: string[] = img;


  ngOnInit(): void {
    
  }
}
