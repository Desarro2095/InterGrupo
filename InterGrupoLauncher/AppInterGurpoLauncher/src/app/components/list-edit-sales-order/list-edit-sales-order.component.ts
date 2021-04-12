import { Component, OnInit } from '@angular/core';
import {ISalesOrder} from 'src/app/interfaces/SalesOrder'
import {SalesOrderService} from 'src/app/services/sales-order.service'

@Component({
  selector: 'app-list-edit-sales-order',
  templateUrl: './list-edit-sales-order.component.html',
  styleUrls: ['./list-edit-sales-order.component.css']
})
export class ListEditSalesOrderComponent implements OnInit {

orders: ISalesOrder[] = []


  constructor(private _salesOrderService : SalesOrderService) { }

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders(){
    this._salesOrderService.getListSalesHeader().subscribe(data =>{
      this.orders = data;
    }, error =>{
      console.log(error);
    })
  }

}
