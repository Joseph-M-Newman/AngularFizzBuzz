import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { response } from 'express';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class FizzBuzzApi {
  private api = inject(HttpClient);
  private apiUrl = `https://localhost:7204/NumberValidation`;
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }
  constructor() { }

  public postAPI(input: number): Observable<any> {
    return this.api.post(this.apiUrl, input, this.httpOptions,);
  }

  public getAPI(): Observable<any> {
    return this.api.get(this.apiUrl + `/getrandomnumber`);
  }
}
