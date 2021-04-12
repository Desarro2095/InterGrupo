import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {SalesOrderService} from 'src/app/services/sales-order.service'
import { ISalesOrder } from 'src/app/interfaces/SalesOrder';
import { ActivatedRoute, Router } from '@angular/router'

@Component({
  selector: 'app-edit-sales-order',
  templateUrl: './edit-sales-order.component.html',
  styleUrls: ['./edit-sales-order.component.css']
})
export class EditSalesOrderComponent implements OnInit {
  editOrder: FormGroup;
  id = 0;

  constructor(private fb: FormBuilder,
              private _salesOrderService : SalesOrderService,
              private router: Router,
              private aRoute: ActivatedRoute ) { 
    this.editOrder = this.fb.group(
      {comment: ['',Validators.required]}
    )
    this.id = +this.aRoute.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
  }
  
  addOrder(){
    console.log(this.editOrder.get('comment')?.value)
    const order : ISalesOrder = {
      salesOrderID: this.id,
      revisionNumber: 0,
      orderDate: new Date(),
      accountNumber: "",
      totalDue: 0,
      comment: this.editOrder.get('comment')?.value
    }
    this._salesOrderService.updateSalesComment(order).subscribe(
      response => {this.router.navigate(['/'])},
      err => console.log(err)
    );
  }
}
