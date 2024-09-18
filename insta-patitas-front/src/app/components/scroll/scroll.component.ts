import { Component, inject } from '@angular/core';
import { NavBarComponent } from '../nav-bar/nav-bar.component';
import { HeaderComponent } from '../header/header.component';
import { ScrollService } from '../../services/scroll.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-scroll',
  standalone: true,
  imports: [NavBarComponent, HeaderComponent, CommonModule],
  templateUrl: './scroll.component.html',
  styleUrl: './scroll.component.css',
})
export class ScrollComponent {
  private readonly posts = inject(ScrollService);

  posts$ = this.posts.getAllPost();
}

interface Post {
  idPost: number;
  titulo: string;
  descripcion: string;
  multimediaPost: string;
  fechaPublicacion: string;
  idUsuario: string;
}
