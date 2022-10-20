import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IStation } from 'src/app/interfaces/station.interface';
import { StationService } from 'src/app/services/station.service';

@Component({
  selector: 'app-station-card',
  templateUrl: './station-card.component.html',
  styleUrls: ['./station-card.component.scss'],
})
export class StationCardComponent implements OnInit {
  @Input() station: IStation;

  @Output() deleteStation = new EventEmitter<boolean>();
  @Output() infoStation = new EventEmitter<boolean>();

  constructor(private stationService: StationService) {}

  ngOnInit(): void {}

  deleteClicked() {
    this.deleteStation.emit(true);
  }

  infoClicked() {
    this.infoStation.emit(true);
  }
}
