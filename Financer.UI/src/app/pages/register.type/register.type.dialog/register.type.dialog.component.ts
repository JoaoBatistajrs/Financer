import {Component, Inject} from '@angular/core';
import {
  MAT_DIALOG_DATA,
  MatDialogRef,
  MatDialogTitle,
  MatDialogContent,
  MatDialogActions,
  MatDialogClose,
} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import {FormsModule} from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { RegisterType, RegisterTypeCreate } from '../../../models/registertype';


@Component({
  selector: 'app-register.type.dialog',
  standalone: true,
  imports: [
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogTitle,
    MatDialogContent,
    MatDialogActions,
    MatDialogClose,
  ],
  templateUrl: './register.type.dialog.component.html',
  styleUrl: './register.type.dialog.component.scss'
})
export class RegisterTypeDialogComponent {

  isEditMode: boolean;

  constructor(
    public dialogRef: MatDialogRef<RegisterTypeDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: RegisterTypeCreate,
  ) {
    this.isEditMode = (data as RegisterType).id !== undefined;
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSaveClick(): void {
    this.dialogRef.close(this.data);
  }

  isFormValid(): boolean {
    return this.data.name.trim() !== '';
  }
}
