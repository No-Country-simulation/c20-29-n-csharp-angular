import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './modal-post.component.html',
  styleUrls: ['./modal-post.component.css']
})
export class ModalComponent {
  info: string | null = null;

  showInfo(option: string) {
    if (this.info === option) {
      this.info = null; 
    } else {
      this.info = option;
    }
  }
}
