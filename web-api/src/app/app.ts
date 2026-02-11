import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Fizzbuzz } from "./fizzbuzz/fizzbuzz";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    Fizzbuzz
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App {

}
