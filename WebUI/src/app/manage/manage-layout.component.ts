import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-manage-layout',
  template: `
    <app-main-navbar></app-main-navbar>
      
      
      <router-outlet></router-outlet>
     
    
  `,
  // styles: [
  // ]
})
export class ManageLayoutComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
