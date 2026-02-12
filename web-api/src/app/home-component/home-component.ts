import { Component } from '@angular/core';
import { RouterOutlet } from "@angular/router";
import { Sidebars } from "../sidebars/sidebars";

@Component({
  selector: 'app-home-component',
  imports: [Sidebars],
  templateUrl: './home-component.html',
  styleUrl: './home-component.css',
})
export class HomeComponent {

}
