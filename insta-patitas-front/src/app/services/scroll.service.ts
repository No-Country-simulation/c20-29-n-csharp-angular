import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ScrollService {
  private readonly _http = inject(HttpClient);

  getAllPost(): Observable<any> {
    return this._http.get(
      'https://r6kc4qqg-simulacion-api.rutasdepiurarentacar.com/Post/GetListaPosts'
    );
  }

  constructor() {}
}
