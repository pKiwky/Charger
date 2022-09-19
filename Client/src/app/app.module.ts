import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { RouterModule, Routes } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { StationCardComponent } from './components/station/station-card/station-card.component';
import { StationListComponent } from './components/station/station-list/station-list.component';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { FooterComponent } from './components/footer/footer.component';

import { TokenInterceptorService } from './interceptors/token-interceptor.service';
import { StationService } from './services/station.service';
import { JwtModule } from '@auth0/angular-jwt';
import { StationCreateComponent } from './components/station/station-create/station-create.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'stations', component: StationListComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
];

export function tokenGetter() {
  return localStorage.getItem('access_token');
}

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    StationCardComponent,
    StationListComponent,
    FooterComponent,
    LoginComponent,
    HomeComponent,
    RegisterComponent,
    StationCreateComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatDialogModule,
    RouterModule.forRoot(appRoutes),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    }),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
      },
    }),
  ],
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
