import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

export interface CatalogueDailog {
  mode: 'Add' | 'Edit' | 'Delete',
  
}

@Component({
  selector: 'app-catalogue-item',
  templateUrl: './catalogue-item.component.html',
  styleUrls: ['./catalogue-item.component.scss']
})
export class CatalogueItemComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) private data: any, private dialogRef: MatDialogRef<CatalogueItemComponent>) { }

  ngOnInit(): void {
  }

}
