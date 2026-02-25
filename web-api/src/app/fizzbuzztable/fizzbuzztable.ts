import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-fizzbuzztable',
  imports: [],
  templateUrl: './fizzbuzztable.html',
  styleUrl: './fizzbuzztable.css',
  inputs: ['ParentData']
})
export class Fizzbuzztable {
  @Input() fizzBuzzData: any
}
