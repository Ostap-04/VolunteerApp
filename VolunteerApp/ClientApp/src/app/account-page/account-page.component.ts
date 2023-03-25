import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-account-page',
  templateUrl: './account-page.component.html',
  styleUrls: ['./account-page.component.css']
})
export class AccountPageComponent implements OnInit {
  chatOpened = false;
  isExpanded: boolean = false;
  constructor() { }

  ngOnInit(): void {
  }

}
