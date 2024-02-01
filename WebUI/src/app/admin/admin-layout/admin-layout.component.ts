import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-layout',
  template: `
       <!-- <app-main-navbar></app-main-navbar> -->
       <div class="container-fluid bg-white p-3 ">
    <div class="row g-0">
        <div class="col-6">
            <img src="assets/images/logo-2.png" alt="">
        </div>
        <div class="col-6 ">
            <div class="row g-0 d-flex  align-items-center">
                <div class="col-1 offset-6">
                    <mat-icon>notifications</mat-icon>
                </div>
                <div class="col-1">
                    <img src="assets/images/avator-1.jpeg" class=" image-fluid rounded bg-dark  rounded-circle " alt="">
                </div>
                <div class="col-2">
                    <h2 class="h2 mb-0 ms-3">Azam</h2>
                     <span class="super-admin">Super Admin</span>
                </div>
                <div class="col-1">
                    <select name="" id="" class="arrow">
                        <option value=""></option>
                        <option value="A">A</option>
                        <option value="A">B</option>
                    </select>                     
                </div>
            </div>
        </div>
    </div>
</div>
       <div class="row g-0 h-100">
      <div class="col-auto shadow justify-content-center border-end border-primary border-1 bg-white">
      <mat-list>
        <button routerLink="dashboard" routerLinkActive="side-menu-active" mat-menu-item>
        <mat-icon style="margin-right: 0;">dashboard_customize</mat-icon>
        Dashboard
      </button>
        <button [routerLink]="'catalogue'" routerLinkActive="side-menu-active" mat-menu-item>
        <mat-icon style="margin-right: 0;">category</mat-icon>
        Catalogue
      </button>
        <button routerLinkActive="side-menu-active" mat-menu-item>
        <mat-icon style="margin-right: 0;">contacts</mat-icon>
        Users
        </button>
    </mat-list>
    </div>
      <div class="col">
      <router-outlet></router-outlet>
      </div>
    </div>
  `,
  styles: [
  ]
})
export class AdminLayoutComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
