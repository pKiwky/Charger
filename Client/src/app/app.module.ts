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
import { AuthGuardService } from './services/auth-guard.service';
import { StationInfoComponent } from './components/station/station-info/station-info.component';
import { CarListComponent } from './components/car/car-list/car-list.component';
import { CarCardComponent } from './components/car/car-card/car-card.component';
import { CarResolver } from './resolvers/car.resolver';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'stations', component: StationListComponent },
  {
    path: 'cars',
    component: CarListComponent,
    canActivate: [AuthGuardService],
    resolve: { cars: CarResolver },
  },
];

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
    StationInfoComponent,
    CarListComponent,
    CarCardComponent,
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
        tokenGetter: () => localStorage.getItem('access_token'),
      },
    }),
  ],
  providers: [
    StationService,
    AuthGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
