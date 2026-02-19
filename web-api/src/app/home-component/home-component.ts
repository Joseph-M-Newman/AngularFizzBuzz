import { Component, inject, Inject } from '@angular/core';
import { AsyncPipe } from '@angular/common'
import { Sidebars } from "../sidebars/sidebars";
import { FizzBuzzApi } from '../fizz-buzz-api';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { BehaviorSubject, Observable } from 'rxjs';
import { Dog } from './IDogData';

@Component({
  selector: 'app-home-component',
  imports: [
    Sidebars,
    MatButtonModule,
    MatTableModule,
    AsyncPipe
  ],
  templateUrl: './home-component.html',
  styleUrl: './home-component.css',
})
export class HomeComponent {
  private apiConnection = inject(FizzBuzzApi);
  private header!: any
  private dogDataObservable = new BehaviorSubject<Dog[]>([])
  dogData: Observable<Dog[]> = this.dogDataObservable.asObservable()
  displayedColumns: string[] = ['id', 'dogBreed', 'lifeMin', 'lifeMax', 'maleWeightMin', 'maleWeightMax', 'femaleWeightMin', 'femaleWeightMax'];

  postDogFactAPI() {
    this.apiConnection.getRandomAPI().subscribe(numberValidations => {
      this.header = { request: Number(numberValidations), uniqueID: null };
      this.apiConnection.postGetDogData(Number(numberValidations)).subscribe(randomDogData => {
        const currentDogObject = this.dogDataObservable.value;
        // below is kinda better than .push? Sending all data from array to a new array allowing for mutations
        this.dogDataObservable.next([
          ...currentDogObject,
          randomDogData as Dog
        ]);
      });
    });
  }
}
