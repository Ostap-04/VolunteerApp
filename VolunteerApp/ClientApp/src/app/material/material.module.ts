import { NgModule } from '@angular/core';
import { MatButtonModule, MatFormFieldModule, MatInputModule, MatIconModule, MatCheckboxModule, MatPaginatorModule } from '@angular/material';

const MaterialComponents = [
  MatButtonModule,
  MatFormFieldModule, 
  MatInputModule,
  MatIconModule,
  MatCheckboxModule,
  MatPaginatorModule
];


@NgModule({
  imports: [MaterialComponents],
  exports: [MaterialComponents]
})
export class MaterialModule { }
