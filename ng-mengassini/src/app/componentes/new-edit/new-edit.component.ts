import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscriber } from 'rxjs';
import { Producto } from 'src/app/models/producto';
import { ProductoService } from 'src/app/services/producto-service.service';
import { MyPopUpComponent } from '../my-pop-up/my-pop-up.component';


@Component({
  selector: 'app-new-edit',
  templateUrl: './new-edit.component.html',
  styleUrls: ['./new-edit.component.scss']
})
export class NewEditComponent implements OnInit {

  //#region Constructor y OnInit

  constructor(private readonly fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private productService: ProductoService,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      nombre: ['', Validators.required],
      cantidadPorUnidad: ['', Validators.required],
      precioUnidad: [0, [Validators.min(0), Validators.required]],
      ordenadas: [0, [Validators.min(0), Validators.required]],
      stock: [0, [Validators.min(0), Validators.required]],
    });

    this.producto = new Producto();
    this.route.paramMap.subscribe(param => {
      if (param.has("id")) {
        let x = parseInt(param.get("id"))
        this.productService.getProducto(x).subscribe({
          next: prod => {
            this.producto = prod;
            this.seteo();
          },
          error: error => {
            this.openDialog("Error. No se pudo recuperar el producto. Verifique ID e intentelo mas tarde.");
          }
        })
      }
    })


  }

  //#endregion

  //#region Declaraciones

  producto: Producto;
  form: FormGroup;

  get nombreCtrl(): AbstractControl {
    return this.form.get('nombre');
  }

  get cantidadPorUnidadCtrl(): AbstractControl {
    return this.form.get('cantidadPorUnidad');
  }

  get precioUnidadCtrl(): AbstractControl {
    return this.form.get('precioUnidad');
  }

  get ordenadasCtrl(): AbstractControl {
    return this.form.get('ordenadas');
  }

  get stockCtrl(): AbstractControl {
    return this.form.get('stock');
  }

  //#endregion

  //#region Funciones y metodos

  openDialog(messaga: string): void {
    const dialogRef = this.dialog.open(MyPopUpComponent, {
      width: '360px',
      data: messaga,
    })
  }

  private seteo = () => {

    if (this.cantidadPorUnidadCtrl) {
      this.cantidadPorUnidadCtrl.setValue(this.producto.Cantidad);
    }
    if (this.precioUnidadCtrl) {
      this.precioUnidadCtrl.setValue(this.producto.Precio);
    }
    if (this.ordenadasCtrl) {
      this.ordenadasCtrl.setValue(this.producto.UOrdenadas);
    }
    if (this.stockCtrl) {
      this.stockCtrl.setValue(this.producto.UStock);
    }
    if (this.nombreCtrl) {
      this.nombreCtrl.setValue(this.producto.Nombre);
    }
  }

  onSubmit(): void {

    console.log(this.form.valid);
    console.log(this.precioUnidadCtrl.errors);
    let blanco: String;
    blanco = this.nombreCtrl.value;
    this.nombreCtrl.setValue(blanco.trim());
    blanco = this.cantidadPorUnidadCtrl.value;
    this.cantidadPorUnidadCtrl.setValue(blanco.trim());

    if (this.form.valid) {
      console.log(this.form.valid);
      this.producto.Nombre = this.nombreCtrl.value;
      this.producto.Precio = this.precioUnidadCtrl.value;
      this.producto.Cantidad = this.cantidadPorUnidadCtrl.value;
      this.producto.UStock = this.stockCtrl.value;
      this.producto.UOrdenadas = this.ordenadasCtrl.value;

      if (this.producto.Id != null) {
        this.productService.putProducto(this.producto, this.producto.Id).subscribe({
          next: data => {
            this.openDialog("El producto fue modificado con Exito.");
          },
          error: error => {
            this.openDialog("Error. No se pudo actualizar el producto. Intentelo mas tarde.");
          }
        });
      } else {
        this.productService.postProducto(this.producto).subscribe({
          next: data => {
            this.openDialog("El producto fue creado con Exito.");
            this.onClickLimpiar();
          },
          error: error => {
            this.openDialog("Error. No se pudo crear el producto. Intentelo mas tarde.");
          }
        });
      }
    }

  }

  onClickLimpiar(): void {
    this.form.reset();
  }

  //#endregion

}