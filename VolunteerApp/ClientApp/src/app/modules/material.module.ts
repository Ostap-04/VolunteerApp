import { NgModule } from '@angular/core';
import { 
  MatButtonModule, 
  MatFormFieldModule, 
  MatInputModule, 
  MatIconModule, 
  MatCheckboxModule, 
  MatPaginatorModule,
  MatExpansionModule,
  MatListModule
} from '@angular/material';

const MaterialComponents = [
  MatButtonModule,
  MatFormFieldModule, 
  MatInputModule,
  MatIconModule,
  MatCheckboxModule,
  MatPaginatorModule,
  MatExpansionModule,
  MatListModule
];


@NgModule({
  imports: [MaterialComponents],
  exports: [MaterialComponents]
})
export class MaterialModule { }
