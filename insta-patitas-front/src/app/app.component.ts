import { Component, OnInit, PLATFORM_ID, Inject } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { SplashScreenComponent } from './components/splash-screen/splash-screen.component';
import { ModalComponent } from './components/modal-post/modal-post.component';
import { routes } from './app.routes';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, SplashScreenComponent, ModalComponent], // Agregamos ModalComponent aquí
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  isLoading = true;

  constructor(private router: Router, @Inject(PLATFORM_ID) private platformId: Object) { }

  ngOnInit(): void {
    this.router.resetConfig(routes);

    if (isPlatformBrowser(this.platformId)) {
      const splashCompleted = localStorage.getItem('splashCompleted') === 'true';
      if (!splashCompleted) {
        this.router.navigate(['/splash']);
      } else {
        this.isLoading = false;
      }
    }
  }

  ngAfterViewInit(): void {
    if (this.isLoading) {
      setTimeout(() => {
        this.isLoading = false;
        if (isPlatformBrowser(this.platformId)) {
          localStorage.setItem('splashCompleted', 'true');
        }

        if (this.router.url === '/splash') {
          this.router.navigate(['/login']);
        }
      }, 3000);
    }
  }
}
