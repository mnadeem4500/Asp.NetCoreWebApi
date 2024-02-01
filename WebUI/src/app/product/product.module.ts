import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductLayoutComponent } from './components/product-layout/product-layout.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../@shared/shared.module';
import { ItemDetailsComponent } from './components/item-details/item-details.component';
import { ListingComponent } from './components/listing/listing.component';

const routes: Routes = [
  { path: 'listing', component: ListingComponent },
  { path: 'details', component: ItemDetailsComponent },
]

@NgModule({
  declarations: [
    ProductLayoutComponent,
    ListingComponent,
    ItemDetailsComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule,
  ]
})
export class ProductModule { }
