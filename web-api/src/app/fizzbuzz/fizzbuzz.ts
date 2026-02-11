
import { Component, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { MatFormField } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input';
import { MatLabel } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { FizzBuzzApi } from '../fizz-buzz-api';


@Component({
  selector: 'app-fizzbuzz',
  standalone: true,
  imports: [
    CommonModule,
    MatFormField,
    MatInputModule,
    MatLabel,
    MatButtonModule,
  ],
  templateUrl: './fizzbuzz.html',
  styleUrl: './fizzbuzz.css',
})
export class Fizzbuzz {
  private apiConnection = inject(FizzBuzzApi);
  inputNumber!: number;
  numberValidations: any[] = [];

  constructor(private http: HttpClient) { }

  getInputVal(input: any) {
    const a = this.apiConnection.getAPI(input.value).subscribe(numberValidations => {
      this.numberValidations = numberValidations;
    })
    console.log(this.numberValidations);
  }
}
