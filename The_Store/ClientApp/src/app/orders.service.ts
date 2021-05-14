import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs'; 

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
readonly APIUrl = 'https://localhost:5001';

constructor(private http:HttpClient) { }

getOrdersList():Observable<any[]>{
  return this.http.get<any>(this.APIUrl + '/GetOrders');
}

createOrder(val:any){
  return this.http.post(this.APIUrl + '/CreateOrder', val);
}

updateOrder(val:any){
  return this.http.put(this.APIUrl + '/UpdateOrder', val);
}

getOrder(val:any){
  return this.http.get(this.APIUrl + '/GetOrderById/' + val);
}

}
