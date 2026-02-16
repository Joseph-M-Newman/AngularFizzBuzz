
import { Component, inject, input, signal } from '@angular/core';
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
  numberValidated: boolean = false;
  message: string = "";
  showExtraContent = false;
  autoInput!: any;
  numberValidations: any[] = [];
  existingGUID: any = "";
  guidToSend: any;
  dictionaryGUID: Map<number, string> = new Map<number, string>();
  private header!: any

  constructor(private http: HttpClient) { }

  getInputVal(input: any) {
    this.message = "";
    if (input.value != null) {
      if (!this.validateInput(Number(input.value))) {
        this.dialog.open(DialogComponent);
        return;
      }
    }
    this.postAPI(input.value);
  }

  postAPI(input: number) {
    this.existingGUID = this.getKeyByValue(this.dictionaryGUID, input);
    this.guidToSend = this.existingGUID ?? null;
    this.apiConnection.postAPI(input, this.guidToSend).subscribe(numberValidations => {
      if (this.getKeyByValue(this.dictionaryGUID, input) == null) {
        if (!this.existingGUID) {
          this.dictionaryGUID.set(Number(input), numberValidations.uniqueID,);
        }
      }
      this._snackbar.open("GUID: " + numberValidations.uniqueID, "Done", {
        duration: 4000,
      });
      console.log("Stored Map:", this.dictionaryGUID);
    });
  }

  validateInput(input: number) {
    if (input > 0 && input <= 100) {
      return true;
    }
    return false;
  }

  doItForMe() {
    this.apiConnection.getAPI().subscribe(numberValidations => {
      this.header = { request: Number(numberValidations), uniqueID: null };
      this.postAPI(Number(numberValidations));
    });
  }

  getKeyByValue(map: Map<number, string>, inputValue: number) {
    for (const [key, value] of map) {
      if (key == inputValue) {
        return value;
      }
    }
    return null;
  }
}