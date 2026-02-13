import { ChangeDetectionStrategy, Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogContent, MatDialogActions, MatDialogTitle, MatDialogClose } from "@angular/material/dialog";

@Component({
  selector: 'dialog-Component',
  templateUrl: 'dialog-Component.html',
  imports: [MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
    MatButtonModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DialogComponent { }
