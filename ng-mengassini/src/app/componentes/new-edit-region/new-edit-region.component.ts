import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscriber } from 'rxjs';
import { Region } from 'src/app/models/region';
import { RegionService } from 'src/app/services/region.service';
import { MyPopUpComponent } from '../my-pop-up/my-pop-up.component';

@Component({
  selector: 'app-new-edit-region',
  templateUrl: './new-edit-region.component.html',
  styleUrls: ['./new-edit-region.component.scss']
})
export class NewEditRegionComponent implements OnInit {

  constructor(private readonly fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private productService: RegionService,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      descripcion: ['', Validators.required]
    });

    this.region = new Region();
    this.route.paramMap.subscribe(param => {
      if (param.has("id")) {
        let x = parseInt(param.get("id"))
        this.productService.getRegion(x).subscribe({
          next: reg => {
            this.region = reg;
            this.seteo();
          },
          error: error => {
            this.openDialog("Error. No se pudo recuperar la region.");
          }
        })
      }
    })


  }

  region: Region;
  form: FormGroup;

  get descripcionCtrl(): AbstractControl {
    return this.form.get('descripcion');
  }

  openDialog(messaga: string): void {
    const dialogRef = this.dialog.open(MyPopUpComponent, {
      width: '300px',
      data: messaga,
    })
  }

  private seteo = () => {
    if (this.descripcionCtrl) {
      this.descripcionCtrl.setValue(this.region.Description);
    }
  }

  onSubmit(): void {

    console.log(this.form.valid);
    let blanco: String;
    blanco = this.descripcionCtrl.value;
    this.descripcionCtrl.setValue(blanco.trim());

    if (this.form.valid) {
      console.log(this.form.valid);
      this.region.Description = this.descripcionCtrl.value;

      if (this.region.Id != null) {
        this.productService.putRegion(this.region, this.region.Id).subscribe({
          next: data => {
            this.openDialog("Region modificada.");
          },
          error: error => {
            this.openDialog("Error. Region no modificada");
          }
        });
      } else {
        this.productService.postRegion(this.region).subscribe({
          next: data => {
            this.openDialog("Region creada.");
            this.onClickLimpiar();
          },
          error: error => {
            this.openDialog("Error. Region no creada.");
          }
        });
      }
    }

  }

  onClickLimpiar(): void {
    this.form.reset();
  }

}
