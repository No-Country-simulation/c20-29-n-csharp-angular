import { Component, inject, OnInit } from '@angular/core';
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
export class ScrollComponent implements OnInit {
  constructor(private scrollService: ScrollService) {}

  posts: any[] = [{}];

  ngOnInit(): void {
    this.scrollService.getAllPost().subscribe({
      next: (res) => {
        this.posts = res;
        this.posts.forEach((posts, index) => {
          if (!`data:image/png;base64,`.includes(posts.multimediaPost)) {
            posts = `data:image/png;base64,${posts.multimediaPost}`;
          }
        });
        console.log(this.posts);
      },
      error: (err) => {
        console.error('error');
      },
    });
  }
  /*() => {
      if (
        `data:image/png;base64,`.includes(this.scrollService.multimediaPost)
      ) {
      }**/
}
