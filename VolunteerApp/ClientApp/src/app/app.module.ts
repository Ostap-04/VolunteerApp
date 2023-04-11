import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { TextMaskModule } from 'angular2-text-mask';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { SignUpBtnComponent } from './signup-button/signup-button.component';
import { LoginBtnComponent } from './login-button/login-button.component'
import { HeroSectionComponent } from './home-page/hero-section/hero-section.component';
import { InfoComponent } from './home-page/info/info.component';
import { FooterComponent } from './footer/footer.component';
import { HomePageComponent } from './home-page/home-page.component';
import { RequestsPageComponent } from './requests-page/requests-page.component';
import { RequestComponent } from './requests-page/request/request.component';
import { AuthorizationPageComponent } from './entry-pages/authorization-page/authorization-page.component';

import { MaterialModule } from './modules/material.module';
import { AppRoutingModule } from './modules/app-routing.module';

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
    RequestComponent,
    AuthorizationPageComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }), 
    BrowserAnimationsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MaterialModule,
    AppRoutingModule,
    TextMaskModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
