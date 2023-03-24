import { Component, OnInit } from '@angular/core';
@Component({
  selector: 'app-requests-page',
  templateUrl: './requests-page.component.html',
  styleUrls: ['./requests-page.component.css'],
})
export class RequestsPageComponent implements OnInit {
  isTabletWidth:boolean = false;
  constructor() { }

  ngOnInit(): void {
    this.isTabletWidth = window.innerWidth <= 991.92;
  }
}
