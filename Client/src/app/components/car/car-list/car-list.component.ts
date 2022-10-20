import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ICar } from 'src/app/interfaces/car.interface';
import { CarService } from 'src/app/services/car.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.scss'],
})
export class CarListComponent implements OnInit {
  cars: ICar[];

  constructor(
    public userService: UserService,
    private actRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    this.actRoute.data.subscribe((data: any) => {
      this.cars = data.cars;
    });
  }
}
