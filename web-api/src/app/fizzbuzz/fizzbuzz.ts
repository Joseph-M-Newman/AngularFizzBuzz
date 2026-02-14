
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
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent } from '../dialog-component/dialog-component';
import { MatSnackBar } from '@angular/material/snack-bar';

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
    MatToolbarModule
  ],
  templateUrl: './fizzbuzz.html',
  styleUrl: './fizzbuzz.css',
})
export class Fizzbuzz {
  private apiConnection = inject(FizzBuzzApi);
  private _snackbar = inject(MatSnackBar);
  dialog = inject(MatDialog);
  fizzBuzzValidation!: string;
  numberValidated: boolean = false
  message: string = "";
  showExtraContent = false
  autoInput!: any;
  numberValidations: any[] = [];
  numberValidationResult!: {inputNumber: number, result: string};
  private header!: any

  constructor(private http: HttpClient) { }

  getInputVal(input: any) {
    this.message = "";
    if (input.value != null) {
      this.validateInput(Number(input.value));
      if (!this.numberValidated) {
        this.dialog.open(DialogComponent);
        return;
      }
    }

    this.header = { inputNumber: Number(input.value) }
    this.postAPI();
  }

  postAPI() {
    this.apiConnection.postAPI(this.header).subscribe(numberValidations => {
      this._snackbar.open(numberValidations.result, "Done", {
        duration: 1500,
      });
    });
  }

  validateInput(input: number) {
    if (input > 0 && input <= 100) {
      this.numberValidated = true;
      return;
    }
    this.numberValidated = false;
  }

  doItForMe() {
    this.apiConnection.getAPI().subscribe(numberValidations => {
      this.header = { inputNumber: Number(numberValidations) };
      this.postAPI();
    });
  }

}