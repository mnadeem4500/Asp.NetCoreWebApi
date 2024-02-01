import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminLayoutComponent } from './admin-layout/admin-layout.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { CatalogueListComponent } from './components/catalogue-list/catalogue-list.component';
import { CatalogueItemComponent } from './components/catalogue-item/catalogue-item.component';
import { SharedModule } from '../@shared/shared.module';
import { AllNgMaterialModule } from '../all-ng-material';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import {MatIconModule} from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';
import {MatTableModule} from '@angular/material/table';

import { CategoryManagementComponent } from './components/category-management/category-management.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent },
  { path: 'catalogue', component: CatalogueListComponent },
  { path: 'category-management', component: CategoryManagementComponent },
  { path: "**", component: DashboardComponent }
]



@NgModule({
  declarations: [
    AdminLayoutComponent,
    DashboardComponent,
    CatalogueListComponent,
    CatalogueItemComponent,
    CategoryManagementComponent
  ],
  imports: [
    MatListModule,
    MatTableModule,
    MatIconModule,
    ReactiveFormsModule,
    CommonModule,
    SharedModule,
    AllNgMaterialModule,
    RouterModule.forChild(routes)
  ]
})
export class AdminModule { }
