import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrdersRoutingModule } from './orders-routing.module';
import { OrdersComponent } from './orders.component';
import { CreateOrdersComponent } from './create-orders/create-orders.component';
import { EditOrdersComponent } from './edit-orders/edit-orders.component';

import { SharedModule } from '../../shared/shared.module';

@NgModule({
  declarations: [OrdersComponent, CreateOrdersComponent, EditOrdersComponent],
  imports: [
    CommonModule,
    OrdersRoutingModule,
    SharedModule
  ]
})
export class OrdersModule { }
