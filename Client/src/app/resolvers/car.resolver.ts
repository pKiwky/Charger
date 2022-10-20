import { Injectable } from '@angular/core';
import {
  Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot,
} from '@angular/router';
import { catchError, map, Observable, of } from 'rxjs';
import { ICar } from '../interfaces/car.interface';
import { CarService } from '../services/car.service';

@Injectable({
  providedIn: 'root',
})
export class CarResolver implements Resolve<any> {
  constructor(private carService: CarService) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<any> {
    return this.carService.getAll().pipe(
      catchError((error) => {
        return of();
      })
    );
  }
}
