import { HttpClient, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
	providedIn: "root",
})
export class RegisterService {
	private url: string =
		"https://r6kc4qqg-simulacion-api.rutasdepiurarentacar.com/Usuarios";

  constructor(private httpClient: HttpClient) { }
  

  register(data: any, img: string | ArrayBuffer): Observable<HttpResponse<any>>{
    console.log(data)
    let body = {
      nombre: data.username,
      correoElectronico: data.email,
      contrasenia: data.password,
      urlFoto: img

    };
    return  this.httpClient.post(this.url, body, {observe: 'response'});
  }
}
