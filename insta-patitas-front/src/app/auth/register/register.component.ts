import { Component, OnInit } from "@angular/core";
import {
	ReactiveFormsModule,
	FormBuilder,
	FormGroup,
	Validators,
	AbstractControl,
} from "@angular/forms";
import { CommonModule } from "@angular/common";
import { RegisterService } from "../../services/register.service";

@Component({
	selector: "app-register",
	standalone: true,
	imports: [CommonModule, ReactiveFormsModule],
	templateUrl: "./register.component.html",
	styleUrls: ["./register.component.css"],
})
export class RegisterComponent implements OnInit {
	// Define el formulario reactivo para el registro
	registerForm: FormGroup;

	// Variable para almacenar la imagen de perfil seleccionada
	profileImage: string | ArrayBuffer;

	// Constructor que inicializa el formulario y su validación
	constructor(private fb: FormBuilder, private registerService: RegisterService) {}

	ngOnInit(): void {
		this.registerForm = this.fb.group({
			username: [
				"",
				Validators.compose([Validators.required, Validators.minLength(3)]),
			],
			email: ["", Validators.compose([Validators.required, Validators.email])],
			password: [
				"",
				Validators.compose([Validators.required, Validators.minLength(6)]),
			],
			confirmPassword: ["", Validators.required],
			terms: [false, Validators.requiredTrue],
		});
	}

	get username() {
		return this.registerForm.get("username")!;
	}

	get email() {
		return this.registerForm.get("email")!;
	}

	get password() {
		return this.registerForm.get("password")!;
	}

	get confirmPassword() {
		return this.registerForm.get("confirmPassword")!;
	}

	get terms() {
		return this.registerForm.get("terms")!;
	}

	sendRegister(): void {
		if (this.registerForm.valid) {
      this.registerService.register(this.registerForm.value, this.profileImage).subscribe({
        next: (res) => console.log(res)
      })
		} else if(this.registerForm.invalid) {
			console.log("Form is invalid");
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

			reader.readAsDataURL(file); // Lee el archivo como una URL de datos
		}
	}
}
