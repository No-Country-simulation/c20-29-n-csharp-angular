import { CanActivateFn } from '@angular/router';

export const authRouteGuard: CanActivateFn = (route, state) => {
  return true;
};
