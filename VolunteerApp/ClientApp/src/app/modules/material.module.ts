import { NgModule } from '@angular/core';
import { 
  MatButtonModule, 
  MatFormFieldModule, 
  MatInputModule, 
  MatIconModule, 
  MatCheckboxModule, 
  MatPaginatorModule,
  MatExpansionModule,
  MatListModule,
  MatRadioModule,
  MatStepperModule
} from '@angular/material';

const MaterialComponents = [
  MatButtonModule,
  MatFormFieldModule, 
  MatInputModule,
  MatIconModule,
  MatCheckboxModule,
  MatPaginatorModule,
  MatExpansionModule,
  MatListModule,
  MatRadioModule,
  MatStepperModule
];


@NgModule({
  imports: [MaterialComponents],
  exports: [MaterialComponents]
})
export class MaterialModule { }
