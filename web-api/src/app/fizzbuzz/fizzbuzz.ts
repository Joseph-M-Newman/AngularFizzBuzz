
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
import { MatDialog, MAT_DIALOG_DATA, MatDialogTitle, MatDialogContent, MatDialogActions } from '@angular/material/dialog';
import { Dialog } from '@angular/cdk/dialog';
import { DialogComponent } from '../dialog-component/dialog-component';

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
  dialog = inject(MatDialog);
  fizzBuzzValidation!: string;
  numberValidated: boolean = false
  message: string = "";
  showExtraContent = false
  numberValidations: any[] = [];
  numberValidationResult!: any;
  private header!: any

  constructor(private http: HttpClient) { }

  getInputVal(input: any) {
    this.message = "";
    this.validateInput(Number(input.value));
    if (!this.numberValidated) {
      this.dialog.open(DialogComponent);
      return;
    }

    this.header = { inputNumber: Number(input.value) }
    this.apiConnection.postAPI(this.header).subscribe(numberValidations => {
      console.log(numberValidations);
    });
  }

  showExtra() {
    this.showExtraContent = true;
  }

  validateInput(input: number) {
    if (input > 0 && input < 100) {
      this.numberValidated = true;
      return;
    }
    this.numberValidated = false;
  }

  getRandomNumberAPI() {
    this.apiConnection.getAPI().subscribe(numberValidations => {
      console.log(numberValidations);
      return
    });
    this.numberValidationResult = this.numberValidations;
  }

}