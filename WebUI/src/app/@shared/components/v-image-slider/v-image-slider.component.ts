import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-v-image-slider',
  templateUrl: './v-image-slider.component.html',
  styleUrls: ['./v-image-slider.component.scss']
})
export class VImageSliderComponent implements OnInit {

  @Input() images: string[] = [];
  currentIndex = 0;
  constructor() { }

  ngOnInit(): void {
  }

  next() {

  }
  prev() {

  }

}
