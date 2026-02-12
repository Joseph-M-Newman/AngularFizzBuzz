import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Fizzbuzz } from "./fizzbuzz/fizzbuzz";
import { Sidebars } from './sidebars/sidebars';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    Sidebars,
    RouterOutlet
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App {

}
