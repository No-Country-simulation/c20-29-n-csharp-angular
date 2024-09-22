import { Component, OnInit } from "@angular/core";
import {
	ReactiveFormsModule,
	FormBuilder,
	FormGroup,
	Validators,
	AbstractControl,
} from "@angular/forms";
import { CommonModule } from "@angular/common";
import { Router, RouterLink } from "@angular/router";
import { LoginService } from "../../services/login.service";
import { CookieService } from "ngx-cookie-service";

@Component({
	selector: "app-login",
	standalone: true,
	imports: [CommonModule, ReactiveFormsModule, RouterLink],
	templateUrl: "./login.component.html",
	styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
	loginForm: FormGroup; // Instancia de FormGroup que representa el formulario de inicio de sesión
  submitted = false; // Propiedad que indica si el formulario ha sido enviado
	responseLogin: string;

	constructor(
		private fb: FormBuilder,
		private loginService: LoginService,
    private router: Router,
    private cookies: CookieService
	) {
		// Inicializa el formulario con dos controles: 'usuario' y 'password', ambos requeridos
		this.loginForm = this.fb.group({
			usuario: ["", [Validators.required]],
			password: ["", Validators.required],
		});
	}

	ngOnInit(): void {}

	// Accede al control 'usuario' del formulario para verificar errores o estado
	get usuario(): AbstractControl {
		return this.loginForm.get("usuario")!;
	}

	// Accede al control 'password' del formulario para verificar errores o estado
	get password(): AbstractControl {
		return this.loginForm.get("password")!;
	}

	// Método que se llama al enviar el formulario
	onSubmit(): void {
		this.submitted = true; // Marca el formulario como enviado
		// Verifica si el formulario es válido y, si es así, imprime los datos en la consola
		if (this.loginForm.valid) {
			this.loginService
				.login(
					this.loginForm.get("usuario").value,
					this.loginForm.get("password").value
				)
				.subscribe({
					next: (res) => {
						this.responseLogin = res.message;
            if (res.data) {
              this.router.navigate(["/inicio"]);
              this.cookies.set(
								"auth",
								`patitas_${res.data.nombre.replace(" ", "_")}`
              );
              
              this.cookies.set('id', res.data.idUsuario)
              
              
            }
					},
					error: (e) => console.log(e),
				});
		}
	}
}
