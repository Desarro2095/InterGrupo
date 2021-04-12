import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ISalesOrder } from 'src/app/interfaces/SalesOrder';

@Injectable({
  providedIn: 'root'
})
export class SalesOrderService {

private myAppUrl = 'https://localhost:44310/Sales';

  constructor(private http: HttpClient) { 

  }
  getListSalesHeader(): Observable<any> {
    return this.http.get(this.myAppUrl + "/GetSalesHeader");
  }

  updateSalesComment(order:ISalesOrder): Observable<any>{
    return this.http.post(this.myAppUrl + "/UpdateSalesHeader", order);
  } 
}
