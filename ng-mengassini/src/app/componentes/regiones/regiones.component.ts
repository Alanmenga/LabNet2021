import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Region } from 'src/app/models/region';
import { RegionService } from 'src/app/services/region.service';
import { MyPopUpComponent } from '../my-pop-up/my-pop-up.component';

@Component({
  selector: 'app-regiones',
  templateUrl: './regiones.component.html',
  styleUrls: ['./regiones.component.scss']
})
export class RegionesComponent implements OnInit {

  listaRegiones: Region[];

  constructor(private regionService: RegionService, public dialog: MatDialog) {
    regionService.getRegions().subscribe({
      next: resp => {
        this.listaRegiones = resp;
      },
      error: error => {
        this.openDialog("Error. No se pudo recuperar lista de regiones.");
      }
    });
  }

  ngOnInit(): void {
  }

  goToUrl = (x) => {
    document.location.href = 'Editar-New-Region/' + x;
  }

  eliminar = (id) => {
    console.log(id);
    this.regionService.deleteRegion(id).subscribe({
      next: data => {
        this.openDialog("Region eliminada.");
        this.regionService.getRegions().subscribe(resp =>
          this.listaRegiones = resp)
      },
      error: error => {
        this.openDialog("Error. Region no eliminada.");
      }
    });
  }
  
  openDialog(messaga: string): void {
    const dialogRef = this.dialog.open(MyPopUpComponent, {
      width: '300px',
      data: messaga,
    })
  }

}
