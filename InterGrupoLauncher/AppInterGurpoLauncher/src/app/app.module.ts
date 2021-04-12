import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';

import { NavbarComponent } from './components/navbar/navbar.component';
import { EditSalesOrderComponent } from './components/edit-sales-order/edit-sales-order.component';
import { ListEditSalesOrderComponent } from './components/list-edit-sales-order/list-edit-sales-order.component';
import { ViewSalesOrderComponent } from './components/view-sales-order/view-sales-order.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    EditSalesOrderComponent,
    ListEditSalesOrderComponent,
    ViewSalesOrderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
