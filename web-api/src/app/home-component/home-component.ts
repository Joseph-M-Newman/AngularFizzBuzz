import { Component, inject, Inject } from '@angular/core';
import { RouterOutlet } from "@angular/router";
import { Sidebars } from "../sidebars/sidebars";
import { FizzBuzzApi } from '../fizz-buzz-api';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-home-component',
  imports: [
    Sidebars,
    MatButtonModule
  ],
  templateUrl: './home-component.html',
  styleUrl: './home-component.css',
})
export class HomeComponent {
  private apiConnection = inject(FizzBuzzApi);
  private header!: any

  postDogFactAPI() {
    this.apiConnection.getRandomAPI().subscribe(numberValidations => {
      this.header = { request: Number(numberValidations), uniqueID: null };
      this.apiConnection.postGetDogData(Number(numberValidations)).subscribe(randomDogData => {
        console.log(randomDogData);
      });
    });
  }
}
