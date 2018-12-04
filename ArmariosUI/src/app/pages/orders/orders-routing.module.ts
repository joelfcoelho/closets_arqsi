import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { OrdersComponent } from './orders.component';

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
    }
  ]
}
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OrdersRoutingModule { }
