import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  // Define el formulario reactivo para el registro
  registerForm: FormGroup;

  // Marca si el formulario ha sido enviado
  submitted = false;

  // Variable para almacenar la imagen de perfil seleccionada
  profileImage: string | ArrayBuffer | null = null;

  // Constructor que inicializa el formulario y su validación
  constructor(private fb: FormBuilder) {
    this.registerForm = this.fb.group({
      username: ['', [Validators.required, Validators.minLength(3)]],  // Campo de nombre de usuario con validación requerida y longitud mínima de 3 caracteres
      email: ['', [Validators.required, Validators.email]],  // Campo de correo electrónico con validación requerida y formato de correo electrónico
      password: ['', [Validators.required, Validators.minLength(6)]],  // Campo de contraseña con validación requerida y longitud mínima de 6 caracteres
      confirmPassword: ['', [Validators.required]],  // Campo de confirmación de contraseña con validación requerida
      terms: [false, Validators.requiredTrue]  // Campo de aceptación de términos con validación de que debe ser verdadero
    }, {
      // Validación personalizada para que las contraseñas coincidan
      validators: this.mustMatch('password', 'confirmPassword')
    });
  }

  // Método para obtener el control del formulario 'username'
  get username(): AbstractControl {
    return this.registerForm.get('username')!;
  }

  // Método para obtener el control del formulario 'email'
  get email(): AbstractControl {
    return this.registerForm.get('email')!;
  }

  // Método para obtener el control del formulario 'password'
  get password(): AbstractControl {
    return this.registerForm.get('password')!;
  }

  // Método para obtener el control del formulario 'confirmPassword'
  get confirmPassword(): AbstractControl {
    return this.registerForm.get('confirmPassword')!;
  }

  // Método para obtener el control del formulario 'terms'
  get terms(): AbstractControl {
    return this.registerForm.get('terms')!;
  }

  // Método para manejar el envío del formulario
  onSubmit(): void {
    this.submitted = true;  // Marca el formulario como enviado
    if (this.registerForm.valid) {
      // Si el formulario es válido, muestra los datos en la consola
      console.log('Register form data:', this.registerForm.value);
    } else {
      // Si el formulario no es válido, muestra un mensaje de error en la consola
      console.log('Form is invalid');
    }
  }

  // Método para manejar el cambio de archivo (selección de imagen de perfil)
  onFileChange(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files[0]) {
      const file = input.files[0];
      const reader = new FileReader();

      // Lee el archivo y actualiza la variable profileImage con el resultado
      reader.onload = () => {
        this.profileImage = reader.result;
      };

      reader.readAsDataURL(file);  // Lee el archivo como una URL de datos
    }
  }

  // Validador personalizado para que las contraseñas coincidan
  mustMatch(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.get(controlName);
      const matchingControl = formGroup.get(matchingControlName);

      // Si el control de coincidencia ya tiene errores, no hacemos nada
      if (matchingControl?.errors && !matchingControl.errors['mustMatch']) {
        return;
      }

      // Si los valores de los controles no coinciden, establece un error de coincidencia
      if (control?.value !== matchingControl?.value) {
        matchingControl?.setErrors({ mustMatch: true });
      } else {
        // Si coinciden, elimina el error de coincidencia
        matchingControl?.setErrors(null);
      }
    };
  }
}