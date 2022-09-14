import { Component, OnInit } from '@angular/core';
import { StationService } from 'src/app/services/station.service';

@Component({
  selector: 'app-station-list',
  templateUrl: './station-list.component.html',
  styleUrls: ['./station-list.component.scss'],
})
export class StationListComponent implements OnInit {
  stations: any;

  constructor(private stationService: StationService) {}

  ngOnInit(): void {
    this.stationService.getAllStations().subscribe(data => {
      this.stations = data;
    });
  }
}
