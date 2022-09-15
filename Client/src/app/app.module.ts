import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { StationCardComponent } from './components/station/station-card/station-card.component';
import { StationListComponent } from './components/station/station-list/station-list.component';

import { StationService } from './services/station.service';
import { FooterComponent } from './components/footer/footer.component';
import { TokenInterceptorService } from './interceptors/token-interceptor.service';
import { LoginComponent } from './components/auth/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    StationCardComponent,
    StationListComponent,
    FooterComponent,
    LoginComponent
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule],
  providers: [
    StationService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
