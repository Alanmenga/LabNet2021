import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Producto } from 'src/app/models/producto';
import { ProductoService } from 'src/app/services/producto.service';
import { MyPopUpComponent } from '../my-pop-up/my-pop-up.component';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.scss']
})
export class ProductosComponent implements OnInit {

  listaProductos: Producto[];

  constructor(private productService: ProductoService, public dialog: MatDialog) {
    productService.getProductos().subscribe({
      next: resp => {
        this.listaProductos = resp;
      },
      error: error => {
        this.openDialog("Error. No se pudo recuperar lista de productos.");
      }
    });
  }
  
  ngOnInit(): void {
  }


  goToUrl = (x) => {
    document.location.href = 'Editar-New/' + x;
  }

  eliminar = (id) => {
    console.log(id);
    this.productService.deleteProducto(id).subscribe({
      next: data => {
        this.openDialog("Producto eliminado.");
        this.productService.getProductos().subscribe(resp =>
          this.listaProductos = resp)
      },
      error: error => {
        this.openDialog("Error. Producto no eliminado.");
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
