import { Component, OnInit } from '@angular/core';
import { StationService } from 'src/app/services/station.service';

@Component({
  selector: 'app-station-create',
  templateUrl: './station-create.component.html',
  styleUrls: ['./station-create.component.scss'],
})
export class StationCreateComponent implements OnInit {
  constructor(private stationService: StationService) {}

  ngOnInit() {}

  onCreateStation() {
    this.stationService.create().subscribe();
  }
}
