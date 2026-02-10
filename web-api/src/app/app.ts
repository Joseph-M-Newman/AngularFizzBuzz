import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    CommonModule
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App {

  protected readonly title = signal('User');
  inputNumber!: number;
  dbReturn!: any;
  constructor(private http: HttpClient) { }

  getInputVal(input: any) {
    this.checkDBFizz(input.value).subscribe({
      next: (res) => {
        this.dbReturn = res
      },
      error: (err) => {
        console.log(err)
      }
    });
  }

  checkDBFizz(input: any): Observable<any> {
    const url = `api/numbers/?id=${input}`;
    console.log(url);
    return this.http.get(url);
  }

  getRes() {
    //If no input is entered; dbReturn ALWAYS will return the full DB...
    //TODO: Add logic for both undefined return => Example: 999 submited -> undefined returned from DB
    //TODO: Don't let submit run if nothing is in the input box
    const resID = this.dbReturn[0].id;
    const value = this.dbReturn[0].name;
    console.log(this.dbReturn);
    alert(resID + " " + value);
  }
}
