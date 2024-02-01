import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AboutLayoutComponent } from './components/about-layout/about-layout.component';
import { SharedModule } from '../@shared/shared.module';
import { RouterModule, Routes } from '@angular/router';
import { AboutusComponent } from './components/aboutus/aboutus.component';

const router: Routes = [
  { path: '', component: AboutusComponent },
  { path: '**', redirectTo: 'aboutus' }];

@NgModule({
  declarations: [
    AboutLayoutComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule,
    RouterModule.forChild(router)
  ]
})
export class AboutModule { }
