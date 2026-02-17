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
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })

  }
  constructor() { }

  public postFizzBuzzAPI(input: number, uniqueID: string | null): Observable<any> {
    const params = this.buildParams(uniqueID);
    return this.api.post(this.apiUrl + `/validatefizzbuzz`, input, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      params: params
    });
  }

  public getRandomAPI(): Observable<any> {
    return this.api.get(this.apiUrl + `/getrandomnumber`);
  }

  public postGetDogData(input: number) {
    return this.api.post(this.apiUrl + `/getrandomdogfact`, input, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    });
  }

  public buildParams(uniqueID: string | null) {
    let param = new HttpParams()
    if (uniqueID && uniqueID !== '') {
      param.set('uniqueID', uniqueID);
    }
    return param;
  }
}
