import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { authRouteGuard } from './auth-route.guard';

describe('authRouteGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => authRouteGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
