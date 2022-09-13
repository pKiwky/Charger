import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-station-list',
  templateUrl: './station-list.component.html',
  styleUrls: ['./station-list.component.scss'],
})
export class StationListComponent implements OnInit {
  stations: Array<any> = [
    {
      Name: 'Salut',
    },
    {
      Name: 'Salut2',
    },
    {
      Name: 'Salut3',
    },
    {
      Name: 'Salut4',
    },
  ];

  constructor() {}

  ngOnInit(): void {}
}
