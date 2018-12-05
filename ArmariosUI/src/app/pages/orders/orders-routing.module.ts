import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrdersComponent } from './orders.component';
import { CreateOrdersComponent } from './create-orders/create-orders.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Encomendas'
    },
    children: [{
      path: '',
      component: OrdersComponent,
      pathMatch: 'full',
      data: {
        title: 'Lista'
      }
    },
    {
      path: 'criar',
      data: {
        title: 'Criar encomenda'
      },
      component: CreateOrdersComponent
    }

  ]
}
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }
