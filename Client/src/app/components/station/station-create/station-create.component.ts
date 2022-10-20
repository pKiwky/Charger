import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { Station } from 'src/app/models/station.model';
import { StationService } from 'src/app/services/station.service';

@Component({
  selector: 'app-station-create',
  templateUrl: './station-create.component.html',
  styleUrls: ['./station-create.component.scss'],
})
export class StationCreateComponent implements OnInit {
  stationForm: FormGroup;

  constructor(
    private stationService: StationService,
    private toastrServie: ToastrService,
    private dialogRef: MatDialogRef<StationCreateComponent>
  ) {}

  ngOnInit() {
    this.stationForm = new FormGroup({
      city: new FormControl(''),
      street: new FormControl(''),
      latitude: new FormControl(0.0),
      longitude: new FormControl(0.0),
    });
  }

  onCreateStation() {
    var station: Station = {
      id: 0,
      city: this.stationForm.get('city')?.value,
      street: this.stationForm.get('street')?.value,
      latitude: this.stationForm.get('latitude')?.value,
      longitude: this.stationForm.get('longitude')?.value,
    };

    this.stationService.create(station).subscribe({
      next: (response) => {
        this.toastrServie.success('Station was successfully created.');
        this.closeModal();

        setInterval(() => {
          window.location.reload();
        }, 1000);
      },
    });
  }

  closeModal() {
    this.dialogRef.close();
  }
}
