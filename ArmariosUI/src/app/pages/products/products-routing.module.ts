import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductsComponent } from './products.component';
import { CreateProductsComponent } from './create-products/create-products.component';

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
      },
    },
      {
        path: 'criar',
        data: {
          title: 'Criar Produto'
        },
        component: CreateProductsComponent
      }

  ]
}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
