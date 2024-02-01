// // // import { Component } from '@angular/core';
// // // import { FormBuilder, FormGroup, Validators } from '@angular/forms';

// // // @Component({
// // //   selector: 'app-category-management',
// // //   templateUrl: './category-management.component.html',
// // //   styleUrls: ['./category-management.component.scss'],
// // // })
// // // export class CategoryManagementComponent {

// // //   categoryForm: FormGroup;
// // //   categories: { name: string }[] = [{ name: 'Layout' }, { name: 'Cars' }, { name: 'Motors' }];
// // //   searchText: string = '';

// // //   constructor(private formBuilder: FormBuilder) {
// // //     this.categoryForm = this.formBuilder.group({
// // //       name: ['', [Validators.required]],
// // //       parentId: [''],
// // //       icon: ['', [Validators.required]],
// // //       maxAllowedImages: [''],
// // //       postValidity: [''],
// // //     });
// // //   }

// // //   onSubmit() {
// // //     if (this.categoryForm.valid) {
// // //       const formData = this.categoryForm.value;
// // //       console.log('Form Data Submitted:', formData);
// // //     }
// // //   }

// // //   onSearch() {
// // //     // Filter the categories based on the search text
// // //     this.categories = this.categories.filter(category => category.name.includes(this.searchText));
// // //   }
// // // }


// // // import { Component, OnInit } from '@angular/core';
// // // import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// // // import { MatTableDataSource } from '@angular/material/table';

// // // @Component({
// // //   selector: 'app-category-management',
// // //   templateUrl: './category-management.component.html',
// // //   styleUrls: ['./category-management.component.scss'],
// // // })
// // // export class CategoryManagementComponent implements OnInit {

// // //   categoryForm: FormGroup;
// // //   categories: { name: string }[] = [{ name: 'Layout' }, { name: 'Cars' }, { name: 'Motors' }];
// // //   searchText: string = '';
// // //   dataSource: MatTableDataSource<{ name: string }> = new MatTableDataSource(this.categories);

// // //   constructor(private formBuilder: FormBuilder) {
// // //     this.categoryForm = this.formBuilder.group({
// // //       name: ['', [Validators.required]],
// // //       parentId: [''],
// // //       icon: ['', [Validators.required]],
// // //       maxAllowedImages: [''],
// // //       postValidity: [''],
// // //     });
// // //   }

// // //   ngOnInit() {
// // //     this.dataSource.filterPredicate = (data, filter) => {
// // //       return data.name.includes(filter);
// // //     };
// // //   }

// // //   onSubmit() {
// // //     if (this.categoryForm.valid) {
// // //       const formData = this.categoryForm.value;
// // //       this.categories.push(formData);
// // //       this.dataSource.data = this.categories;
// // //       this.categoryForm.reset();
// // //     }
// // //   }

// // //   onSearch() {
// // //     this.dataSource.filter = this.searchText;
// // //   }
// // // }




// // // category-management.component.ts

// // import { Component, OnInit } from '@angular/core';
// // import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// // import { MatTableDataSource } from '@angular/material/table';

// // @Component({
// //   selector: 'app-category-management',
// //   templateUrl: './category-management.component.html',
// //   styleUrls: ['./category-management.component.scss'],
// // })
// // export class CategoryManagementComponent implements OnInit {
// //   categoryForm: FormGroup;
// //   categories: { name: string }[] = [{ name: 'Layout' }, { name: 'Cars' }, { name: 'Motors' }];
// //   searchText: string = '';
// //   dataSource: MatTableDataSource<{ name: string }> = new MatTableDataSource(this.categories);
// //   displayedColumns: string[] = ['name'];

// //   constructor(private formBuilder: FormBuilder) {
// //     this.categoryForm = this.formBuilder.group({
// //       name: ['', [Validators.required]],
// //       parentId: [''],
// //       icon: ['', [Validators.required]],
// //       maxAllowedImages: [''],
// //       postValidity: [''],
// //     });
// //   }

// //   ngOnInit() {
// //     this.dataSource.filterPredicate = (data, filter) => {
// //       return data.name.toLowerCase().includes(filter.toLowerCase());
// //     };
// //   }

// //   onSubmit() {
// //     if (this.categoryForm.valid) {
// //       const formData = this.categoryForm.value;
// //       this.categories.push(formData);
// //       this.dataSource.data = this.categories;
// //       this.categoryForm.reset();
// //     }
// //   }

// //   onSearch() {
// //     this.dataSource.filter = this.searchText.trim().toLowerCase();
// //   }
// // }




// import { Component, OnInit } from '@angular/core';
// import { FormBuilder, FormGroup, Validators } from '@angular/forms';
// import { MatTableDataSource } from '@angular/material/table';

// interface PeriodicElement {
//   name: string;
//   position: number;
//   weight: number;
//   symbol: string;
// }

// const ELEMENT_DATA: PeriodicElement[] = [
//   { position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H' },
//   { position: 2, name: 'Helium', weight: 4.0026, symbol: 'He' },
//   { position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li' },
//   // Add more dynamic data as needed
// ];

// @Component({
//   selector: 'app-category-management',
//   templateUrl: './category-management.component.html',
//   styleUrls: ['./category-management.component.scss'],
// })
// export class CategoryManagementComponent implements OnInit {
//   categoryForm: FormGroup;
//   categories: { name: string }[] = [{ name: 'Layout' }, { name: 'Cars' }, { name: 'Motors' }];
//   searchText: string = '';
//   dataSource: MatTableDataSource<PeriodicElement>;

//   displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];

//   constructor(private formBuilder: FormBuilder) {
//     this.categoryForm = this.formBuilder.group({
//       name: ['', [Validators.required]],
//       parentId: [''],
//       icon: ['', [Validators.required]],
//       maxAllowedImages: [''],
//       postValidity: [''],
//     });

//     // Initialize dataSource with dynamic data
//     this.dataSource = new MatTableDataSource(ELEMENT_DATA);
//   }

//   ngOnInit() {
//     this.dataSource.filterPredicate = (data, filter) => {
//       return data.name.toLowerCase().includes(filter.toLowerCase());
//     };
//   }

//   onSubmit() {
//     if (this.categoryForm.valid) {
//       const formData = this.categoryForm.value;
//       this.categories.push(formData);
//       this.dataSource.data = ELEMENT_DATA; // Update data with the dynamic data
//       this.categoryForm.reset();
//     }
//   }

//   onSearch() {
//     this.dataSource.filter = this.searchText.trim().toLowerCase();
//   }
// }









import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';

interface PeriodicElement {
  image: string;
  name: string;
  description: string;
  slug: string;
  count: number;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { image: 'assets/images/c-1.jpg', name: 'Cars', description: 'Description 1', slug: 'hydrogen-slug', count: 5 },
  { image: 'assets/images/c-2.jpeg', name: 'Motors', description: 'Description 2', slug: 'helium-slug', count: 10 },
  { image: 'assets/images/car3.webp', name: 'Uncategorized', description: 'Description 3', slug: 'lithium-slug', count: 8 },
  // Add more dynamic data as needed
];

@Component({
  selector: 'app-category-management',
  templateUrl: './category-management.component.html',
  styleUrls: ['./category-management.component.scss'],
})
export class CategoryManagementComponent implements OnInit {
  categoryForm: FormGroup;
  categories: { name: string }[] = [{ name: 'Layout' }, { name: 'Cars' }, { name: 'Motors' }];
  searchText: string = '';
  dataSource: MatTableDataSource<PeriodicElement>;

  displayedColumns: string[] = ['image', 'name', 'description', 'slug', 'count'];

  constructor(private formBuilder: FormBuilder) {
    this.categoryForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      parentId: [''],
      icon: ['', [Validators.required]],
      maxAllowedImages: [''],
      postValidity: [''],
    });

    // Initialize dataSource with dynamic data
    this.dataSource = new MatTableDataSource(ELEMENT_DATA);
  }

  ngOnInit() {
    this.dataSource.filterPredicate = (data, filter) => {
      return data.name.toLowerCase().includes(filter.toLowerCase());
    };
  }

  onSubmit() {
    if (this.categoryForm.valid) {
      const formData = this.categoryForm.value;
      this.categories.push(formData);
      this.dataSource.data = ELEMENT_DATA; // Update data with the dynamic data
      this.categoryForm.reset();
    }
  }

  onSearch() {
    this.dataSource.filter = this.searchText.trim().toLowerCase();
  }
}
