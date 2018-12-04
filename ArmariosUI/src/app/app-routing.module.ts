import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { FullLayoutComponent } from './layouts/full-layout.component';


import { P404Component } from './pages/404.component';



export const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
  {
    path: '',
    component: FullLayoutComponent,
    data: {
      title: 'Início'
    },
    children: [
      {
        path: 'home',
        loadChildren: './pages/home/home.module#HomeModule',
      },
      {
        path: 'produtos',
        loadChildren: './pages/products/products.module#ProductsModule'
      },
      {
        path: 'encomendas',
        loadChildren: './pages/orders/orders.module#OrdersModule'
      },

    ]
  },
  { path: 'not-found', component: P404Component },
  { path: '**', redirectTo: '/not-found' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  declarations: [P404Component]
})
export class AppRoutingModule { }
