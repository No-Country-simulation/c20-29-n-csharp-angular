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
  loginForm: FormGroup;  // Instancia de FormGroup que representa el formulario de inicio de sesión
  submitted = false;  // Propiedad que indica si el formulario ha sido enviado

  constructor(private fb: FormBuilder) {
    // Inicializa el formulario con dos controles: 'usuario' y 'password', ambos requeridos
    this.loginForm = this.fb.group({
      usuario: ['', [Validators.required]], 
      password: ['', Validators.required]
    });
  }

  // Accede al control 'usuario' del formulario para verificar errores o estado
  get usuario(): AbstractControl {
    return this.loginForm.get('usuario')!;
  }

  // Accede al control 'password' del formulario para verificar errores o estado
  get password(): AbstractControl {
    return this.loginForm.get('password')!;
  }

  // Método que se llama al enviar el formulario
  onSubmit(): void {
    this.submitted = true;  // Marca el formulario como enviado
    // Verifica si el formulario es válido y, si es así, imprime los datos en la consola
    if (this.loginForm.valid) {
      console.log('Login form data:', this.loginForm.value);
    }
  }
}
