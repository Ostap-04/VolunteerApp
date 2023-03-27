import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { SignUpBtnComponent } from './signup-button/signup-button.component';
import { LoginBtnComponent } from './login-button/login-button.component'
import { HeroSectionComponent } from './home-page/hero-section/hero-section.component';
import { InfoComponent } from './home-page/info/info.component';
import { FooterComponent } from './footer/footer.component';
import { HomePageComponent } from './home-page/home-page.component';
import { RequestsPageComponent } from './requests-page/requests-page.component';
import { MaterialModule } from './material/material.module';
import { RequestComponent } from './requests-page/request/request.component';

const appRoutes: Routes = [
  {path: '', component: HomePageComponent},
  {path: 'requests-page', component: RequestsPageComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    HomePageComponent,
    HeaderComponent,
    SignUpBtnComponent,
    LoginBtnComponent,
    HeroSectionComponent,
    InfoComponent,
    FooterComponent,
    RequestsPageComponent,
    RequestComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }), 
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MaterialModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
