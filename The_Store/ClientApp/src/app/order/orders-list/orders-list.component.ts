import { Component, OnInit } from '@angular/core';
import { OrdersService } from 'src/app/orders.service';

@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.scss']
})
export class OrdersListComponent implements OnInit {

  constructor(private service:OrdersService) { }

  OrdersList:any = [];

  ngOnInit(): void {
    this.refreshOrdersList();
  }

  refreshOrdersList(){
    this.service.getOrdersList().subscribe(data => {
      this.OrdersList = data;
    });
  }

}
