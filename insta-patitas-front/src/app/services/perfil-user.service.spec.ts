import { TestBed } from '@angular/core/testing';

import { PerfilUserService } from './perfil-user.service';

describe('PerfilUserService', () => {
  let service: PerfilUserService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PerfilUserService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
