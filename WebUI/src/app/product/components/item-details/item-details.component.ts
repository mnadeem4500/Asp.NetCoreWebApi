import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { GalleryItem, ImageItem } from '@ngx-gallery/core';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.scss'],
})
export class ItemDetailsComponent implements OnInit {

  // images: string[] = ['assets/images/image.jpg', 'assets/images/image.jpg', 'assets/images/image.jpg', 'assets/images/image.jpg'];

  items: GalleryItem[] = [];
  imageData = data;
  constructor() {
    this.items = this.imageData.map(item => new ImageItem({ src: item.srcUrl, thumb: item.previewUrl }));

    console.log(this.items)
  }

  ngOnInit(): void {
  }

  onSwiper(swiper: any) {
    console.log(swiper);
  }

  onSlideChange() {
    console.log('slide change');
  }

}

const data = [
  {
    srcUrl: 'assets/images/image.jpg',
    previewUrl: 'assets/images/image.jpg'
  },
  {
    srcUrl: 'assets/images/image.jpg',
    previewUrl: 'assets/images/image.jpg'
  },
  {
    srcUrl: 'assets/images/image.jpg',
    previewUrl: 'assets/images/image.jpg'
  },
  {
    srcUrl: 'assets/images/image.jpg',
    previewUrl: 'assets/images/image.jpg'
  }
];
