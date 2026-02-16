import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { inject, Injectable, Query } from '@angular/core';
import { response } from 'express';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class FizzBuzzApi {
  private api = inject(HttpClient);
  private apiUrl = `https://localhost:7204/NumberValidation`;
  private params = new HttpParams();
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })

  }
  constructor() { }

  public postAPI(input: number, uniqueID: string | null): Observable<any> {
    if (uniqueID && uniqueID !== '')
      this.params = this.params.set('uniqueID', uniqueID)
    console.log("UniqueID: " + uniqueID);
    return this.api.post(this.apiUrl + `/validatefizzbuzz`, input, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      params: this.params
    });
  }

  public getAPI(): Observable<any> {
    return this.api.get(this.apiUrl + `/getrandomnumber`);
  }

}
