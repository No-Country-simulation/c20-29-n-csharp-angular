import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";

@Injectable({
	providedIn: "root",
})
export class LoginService {
	constructor(private httpClient: HttpClient) {}
	private url: string =
		"https://r6kc4qqg-simulacion-api.rutasdepiurarentacar.com/Usuarios/ValidarLogin";
	login(usuario: string, password: string): Observable<any> {
		const body: Object = {
			correoElectronico: usuario,
			contrasenia: password,
		};
		return this.httpClient.post(this.url, body);
  }
  
}
