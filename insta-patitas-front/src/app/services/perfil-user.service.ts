import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: "root",
})
export class PerfilUserService {
	private url: string =
		"https://r6kc4qqg-simulacion-api.rutasdepiurarentacar.com";

	constructor(private httpClient: HttpClient,@Inject(CookieService) private cookies : CookieService) {}

	user(): Observable<any> {
		return this.httpClient.get(
			`${this.url}/Usuarios/${this.cookies.get("id")}`
		);
  }
  
  post(): Observable<any> {
    return this.httpClient.get(`${this.url}/Post/GetListaPosts`);
  }
}
