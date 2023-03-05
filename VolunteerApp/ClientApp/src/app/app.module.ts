import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { SignUpBtnComponent } from './signup-button/signup-button.component';
import { LoginBtnComponent } from './login-button/login-button.component'
import { HeroSectionComponent } from './hero-section/hero-section.component';
import { InfoComponent } from './info/info.component';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SignUpBtnComponent,
    LoginBtnComponent,
    HeroSectionComponent,
    InfoComponent,
    FooterComponent,
  ],
  imports: [BrowserModule.withServerTransition({ appId: 'ng-cli-universal' })],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
