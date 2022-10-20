import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IStation } from 'src/app/interfaces/station.interface';

@Component({
  selector: 'app-station-info',
  templateUrl: './station-info.component.html',
  styleUrls: ['./station-info.component.scss'],
})
export class StationInfoComponent implements OnInit {
  stationForm: FormGroup;

  constructor(@Inject(MAT_DIALOG_DATA) public data: IStation) {}

  ngOnInit() {
    this.stationForm = new FormGroup({
      city: new FormControl(this.data.city),
      street: new FormControl(this.data.street),
      latitude: new FormControl(this.data.longitude),
      longitude: new FormControl(this.data.latitude),
    });
  }
}
