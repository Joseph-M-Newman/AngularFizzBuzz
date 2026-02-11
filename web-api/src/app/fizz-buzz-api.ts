import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class FizzBuzzApi {
  private api = inject(HttpClient);
  private apiUrl = `https://localhost:7204/NumberValidation`;

  constructor() { }

  public getAPI(input: any): Observable<any> {
    return this.api.get(this.apiUrl + `/${input}`);
  }
}
