
import { Component, inject, signal } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { MatFormField } from '@angular/material/form-field'
import { MatInputModule } from '@angular/material/input';
import { MatLabel } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { FizzBuzzApi } from '../fizz-buzz-api';
import { MatSidenavModule } from '@angular/material/sidenav'
import { MatToolbarModule } from '@angular/material/toolbar'
import { Sidebars } from '../sidebars/sidebars';
import { RouterOutlet } from "@angular/router";

@Component({
  selector: 'app-fizzbuzz',
  standalone: true,
  imports: [
    CommonModule,
    MatFormField,
    MatInputModule,
    MatLabel,
    MatButtonModule,
    MatSidenavModule,
    MatToolbarModule,
    Sidebars
  ],
  templateUrl: './fizzbuzz.html',
  styleUrl: './fizzbuzz.css',
})
export class Fizzbuzz {
  private apiConnection = inject(FizzBuzzApi);
  inputNumber!: number;
  showExtraContent = false
  numberValidations: any[] = [];

  constructor(private http: HttpClient) { }

  getInputVal(input: any) {
    this.apiConnection.getAPI(input.value).subscribe(numberValidations => {
      if (numberValidations != null) {
        this.numberValidations = numberValidations;
        return
      }
      this.numberValidations = [];
    });
    this.checkIfReturned(this.numberValidations);
    console.log(this.numberValidations);
  }

  showExtra() {
    this.showExtraContent = true;
  }

  checkIfReturned(APIReturn: any[]) {
    return
  }
}
