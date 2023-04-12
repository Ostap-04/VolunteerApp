import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';

import { RequestsPageComponent } from '../requests-page/requests-page.component';
import { HomePageComponent } from '../home-page/home-page.component';
import { AuthorizationPageComponent } from '../entry-pages/authorization-page/authorization-page.component';

const appRoutes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'requests-page', component: RequestsPageComponent },
  { path: 'authorization-page', component: AuthorizationPageComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule {}