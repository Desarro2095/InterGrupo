import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListEditSalesOrderComponent } from './components/list-edit-sales-order/list-edit-sales-order.component';
import { EditSalesOrderComponent } from './components/edit-sales-order/edit-sales-order.component';
import { ViewSalesOrderComponent } from './components/view-sales-order/view-sales-order.component';
 
const routes: Routes = [
  { path: '', component: ListEditSalesOrderComponent},
  { path: 'edit', component: EditSalesOrderComponent},
  { path: 'edit/:id', component: EditSalesOrderComponent},
  { path: 'view/:id', component: ViewSalesOrderComponent },
  { path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
