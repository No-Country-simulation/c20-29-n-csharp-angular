// splash.guard.ts
import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { isPlatformBrowser } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class SplashGuard implements CanActivate {
  constructor(private router: Router, @Inject(PLATFORM_ID) private platformId: Object) {}

  canActivate(): boolean {
    if (isPlatformBrowser(this.platformId)) {
      const splashCompleted = localStorage.getItem('splashCompleted') === 'true';
      if (splashCompleted) {
        return true;
      } else {
        this.router.navigate(['/splash']);
        return false;
      }
    } else {

      return true;
    }
  }
}
