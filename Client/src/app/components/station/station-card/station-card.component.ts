import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-station-card',
  templateUrl: './station-card.component.html',
  styleUrls: ['./station-card.component.scss'],
})
export class StationCardComponent implements OnInit {
  @Input() station: any;

  constructor() {}

  ngOnInit(): void {}
}
