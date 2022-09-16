import {
  Component,
  OnInit,
  Input,
  ChangeDetectorRef,
  ChangeDetectionStrategy,
} from '@angular/core';
import { IStation } from 'src/app/interfaces/station.interface';
import { StationService } from 'src/app/services/station.service';

@Component({
  selector: 'app-station-list',
  templateUrl: './station-list.component.html',
  styleUrls: ['./station-list.component.scss'],
})
export class StationListComponent implements OnInit {
  @Input() pageSize: number = 4;

  stations: any[];
  currentPage: number = 1;
  lastPage: number = 0;

  constructor(private stationService: StationService) {}

  ngOnInit() {
    this.setPage(1);
  }

  setPage(pageNumber: number) {
    this.currentPage = pageNumber;

    this.stationService
      .getPaginated(this.currentPage, this.pageSize)
      .subscribe((response) => {
        this.stations = response.results;
        this.lastPage = response.lastPage;
      });
  }

  onDeleteStation(station: IStation) {
    this.stationService.delete(station.id).subscribe((response) => {
      this.stations = this.stations.filter(
        (item: IStation) => item !== station
      );

      // Delete last element from page. Go one page back.
      if(this.stations.length == 0) {
        this.currentPage--;
        this.lastPage--;

        if(this.currentPage < 1) {
          this.currentPage = 1;
        }
        if(this.lastPage < 1) {
          this.lastPage = 1;
        }

        console.log(this.currentPage);
        console.log(this.lastPage);

      }

      this.stationService
        .getPaginated(this.currentPage, this.pageSize)
        .subscribe((response) => {
          this.stations = response.results;
          this.lastPage = response.lastPage;
        });
    });
  }
}
