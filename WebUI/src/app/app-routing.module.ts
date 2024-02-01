import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutLayoutComponent } from './about/components/about-layout/about-layout.component';
import { AdminLayoutComponent } from './admin/admin-layout/admin-layout.component';
import { ManageLayoutComponent } from './manage/manage-layout.component';
import { ProductLayoutComponent } from './product/components/product-layout/product-layout.component';
import { AuthLayoutComponent } from './auth/auth-layout.component';


const routes: Routes = [
  {
    path: '', children: [
      {
        path: '', loadChildren: () => import('./home/home.module').then(m => m.HomeModule)
      }
    ],

  },

  {
    path: 'product', component: ProductLayoutComponent, children: [
      {
        path: '', loadChildren: () => import('./product/product.module').then(m => m.ProductModule)
      }
    ],

  },
  {
    path: 'about', component: AboutLayoutComponent, children: [
      {
        path: '', loadChildren: () => import('./about/about.module').then(m => m.AboutModule)
      }
    ],

  },
  {
    path: 'manage', component: ManageLayoutComponent, children: [
      {
        path: '', loadChildren: () => import('./manage/manage.module').then(m => m.ManageModule)
      }
    ],

  },
  {
    path: 'admin', component: AdminLayoutComponent, children: [
      {
        path: '', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule)
      }
    ],

  },

  {
    path: 'auth', component: AuthLayoutComponent, children: [
      {
        path: '', loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)
      }
    ],

  },
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
