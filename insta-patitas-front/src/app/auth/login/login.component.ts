import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup;
  submitted = false;  // Nueva propiedad para controlar si se ha enviado el formulario

  constructor(private fb: FormBuilder) {
    this.loginForm = this.fb.group({
      usuario: ['', [Validators.required]], 
      password: ['', Validators.required]
    });
  }

  get usuario(): AbstractControl {
    return this.loginForm.get('usuario')!;
  }

  get password(): AbstractControl {
    return this.loginForm.get('password')!;
  }

  onSubmit(): void {
    this.submitted = true;  // Marca el formulario como enviado
    if (this.loginForm.valid) {
      console.log('Login form data:', this.loginForm.value);
    }
  }
}
