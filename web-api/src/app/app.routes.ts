import { Routes } from '@angular/router';
import { Fizzbuzz } from './fizzbuzz/fizzbuzz';
import { App } from './app';
import { HomeComponent } from './home-component/home-component';

export const routes: Routes = [
    { path: 'FizzBuzz', component: Fizzbuzz },
    { path: '', component: HomeComponent }

];
