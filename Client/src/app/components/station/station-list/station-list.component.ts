import { Component, OnInit, Input } from '@angular/core';
import { IStation } from 'src/app/interfaces/station.interface';
import { StationService } from 'src/app/services/station.service';
import { ToastrService } from 'ngx-toastr';
import { UserService } from 'src/app/services/user.service';
import { StationCreateComponent } from '../station-create/station-create.component';
import {
  MatDialog,
  MatDialogConfig,
  MatDialogRef,
} from '@angular/material/dialog';
import { StationInfoComponent } from '../station-info/station-info.component';

@Component({
  selector: 'app-station-list',
  templateUrl: './station-list.component.html',
  styleUrls: ['./station-list.component.scss'],
})
export class StationListComponent implements OnInit {
  @Input() pageSize: number = 16;

  stations: IStation[];
  currentPage: number = 1;
  lastPage: number = 0;

  dialogConfig = new MatDialogConfig();
  modalCreateStation: MatDialogRef<StationCreateComponent, any> | undefined;
  modalInfoStation: MatDialogRef<StationInfoComponent, any> | undefined;

  constructor(
    private stationService: StationService,
    private toastrService: ToastrService,
    public userService: UserService,
    public matDialog: MatDialog
  ) {}

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
      if (this.stations.length == 0) {
        this.currentPage--;
        this.lastPage--;

        if (this.currentPage < 1) {
          this.currentPage = 1;
        }
        if (this.lastPage < 1) {
          this.lastPage = 1;
        }
      }

      this.stationService
        .getPaginated(this.currentPage, this.pageSize)
        .subscribe((response) => {
          this.stations = response.results;
          this.lastPage = response.lastPage;
        });

      this.toastrService.success('Station was successfully deleted.');
    });
  }

  onCreateStationModal() {
    this.dialogConfig.id = 'app-station-create';
    this.dialogConfig.width = '650px';

    this.modalCreateStation = this.matDialog.open(
      StationCreateComponent,
      this.dialogConfig
    );
  }

  onInfoStation(station: IStation) {
    this.dialogConfig.id = 'app-station-info';
    this.dialogConfig.width = '650px';
    this.dialogConfig.data = station;

    this.modalInfoStation = this.matDialog.open(
      StationInfoComponent,
      this.dialogConfig
    );
  }
}
