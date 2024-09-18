import { HttpClient, HttpRequest, HttpResponse } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { CookieService } from "ngx-cookie-service";
import { Observable } from "rxjs";

@Injectable({
	providedIn: "root",
})
export class CreatePostService {
	private url: string =
		"https://r6kc4qqg-simulacion-api.rutasdepiurarentacar.com/Post/PostPost";

	constructor(
		private httpClient: HttpClient,
		@Inject(CookieService) private cookie: CookieService
	) {}

  post(post: any, img: string): Observable<any> {

    const formData = new FormData();

    formData.append('Titulo', post.description);
    formData.append('TipoPost', post.type);
    formData.append('Descripcion', post.description);
    formData.append('IdUsuario', this.cookie.get('id'));
    formData.append('listaArchiva', img);

    console.log(img)

    
		return this.httpClient.post(this.url, formData);
	}
}
