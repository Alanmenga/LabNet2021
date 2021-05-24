import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewEditComponent } from './componentes/new-edit/new-edit.component';
import { ProductosComponent } from './componentes/productos/productos.component';
import { RegionesComponent } from './componentes/regiones/regiones.component';
import { NewEditRegionComponent } from './componentes/new-edit-region/new-edit-region.component';

const routes: Routes = [
  { path:"Productos", component: ProductosComponent },
  { path:"Editar-New/:id", component:NewEditComponent },
  { path:"Editar-New", component:NewEditComponent },
  { path:"Regiones", component: RegionesComponent },
  { path:"Editar-New-Region", component: NewEditRegionComponent },
  { path:"Editar-New-Region/:id", component: NewEditRegionComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
