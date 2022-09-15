import { Component, Output, OnInit, EventEmitter, Input } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { StationService } from 'src/app/services/station.service';

@Component({
  selector: 'app-station-list',
  templateUrl: './station-list.component.html',
  styleUrls: ['./station-list.component.scss'],
})
export class StationListComponent implements OnInit {
  @Input() pageSize: number = 16;
  @Output() changePage = new EventEmitter<any>(true);

  stations: any;
  currentPage: number = 1;
  lastPage: number = 0;

  constructor(
    private stationService: StationService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.setPage(1);
  }

  setPage(pageNumber: number): void {
    this.currentPage = pageNumber;

    this.stationService
      .getPaginated(this.currentPage, this.pageSize)
      .subscribe((response) => {
        this.stations = response.results;
        this.lastPage = response.lastPage;

        this.changePage.emit(this.stations);
      });
  }
}
