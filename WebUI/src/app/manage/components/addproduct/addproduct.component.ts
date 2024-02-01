import { Component } from '@angular/core';

@Component({
  selector: 'app-addproduct',
  templateUrl: './addproduct.component.html',
  styleUrls: ['./addproduct.component.scss']
})
export class AddproductComponent {

  currentStep = 0;

  nextStep() {
    this.currentStep++;
  }

  prevStep() {
    this.currentStep--;
  }
}
// export class AddproductComponent implements OnInit {

//   constructor() { }

//   ngOnInit(): void {
//   }

// }
