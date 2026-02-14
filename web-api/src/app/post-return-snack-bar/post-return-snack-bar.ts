import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBarAction, MatSnackBarActions, MatSnackBarLabel, MatSnackBarRef } from '@angular/material/snack-bar'

@Component({
  selector: 'app-post-return-snack-bar',
  standalone: true,
  imports: [
    MatButtonModule,
    MatSnackBarLabel,
    MatSnackBarActions,
    MatSnackBarAction,
  ],
  templateUrl: './post-return-snack-bar.html',
  styleUrl: './post-return-snack-bar.css',
})
export class PostReturnSnackBar {
  snackBarRef = inject(MatSnackBarRef);
}
