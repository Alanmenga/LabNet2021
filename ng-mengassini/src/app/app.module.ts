import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NewEditComponent } from './componentes/new-edit/new-edit.component';
import { ProductosComponent } from './componentes/productos/productos.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'
import {MatCardModule} from '@angular/material/card';
import {MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import { MyPopUpComponent } from './componentes/my-pop-up/my-pop-up.component';
import { RegionesComponent } from './componentes/regiones/regiones.component';
import { NewEditRegionComponent } from './componentes/new-edit-region/new-edit-region.component';

@NgModule({
  declarations: [
    AppComponent,
    NewEditComponent,
    ProductosComponent,
    MyPopUpComponent,
    RegionesComponent,
    NewEditRegionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatCardModule,
    MatButtonModule,
    MatButtonModule,
    MatDialogModule,
  ],
  entryComponents: [MyPopUpComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
