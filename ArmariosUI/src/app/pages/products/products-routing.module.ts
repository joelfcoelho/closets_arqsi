import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductsComponent } from './products.component';

const routes: Routes = [
  {
    path: '',
    data: {
        title: 'Produtos'
    },
    children: [{
        path: '',
        component: ProductsComponent,
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
export class ProductsRoutingModule { }
