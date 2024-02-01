import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MyProductsComponent } from './components/my-products/my-products.component';
import { ProfileComponent } from './components/profile/profile.component';

import { ManageLayoutComponent } from './manage-layout.component';
import { SharedModule } from '../@shared/shared.module';
import { RouterModule, Routes } from '@angular/router';
import { AddproductComponent } from './components/addproduct/addproduct.component';

const routes: Routes = [
  { path: 'mylisting', component: MyProductsComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'addproduct', component: AddproductComponent },

  { path: "**", redirectTo: "mylisting" }
]

@NgModule({
  declarations: [
    ManageLayoutComponent,
    DashboardComponent,
    MyProductsComponent,
    AddproductComponent,
    ProfileComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class ManageModule { }
