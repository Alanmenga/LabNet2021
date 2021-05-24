import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
@Component({
  selector: 'app-my-pop-up',
  templateUrl: './my-pop-up.component.html',
  styleUrls: ['./my-pop-up.component.scss']
})
export class MyPopUpComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<MyPopUpComponent>,
    @Inject(MAT_DIALOG_DATA) public message: string,
  ) { }

  title: string;

  ngOnInit(): void {
    if (this.message.includes("Error")) {
      this.title = 'No se pudo completar operacion.'
    } else {
      this.title = 'Operacion exitosa.'
    }
  }

  onClickClose(): void {
    this.dialogRef.close();
  }
}
