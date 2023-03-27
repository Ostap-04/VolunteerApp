import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent implements OnInit {
  showMore:boolean = false;
  textOverflow:boolean = false;
  avatar = '';
  userName = 'user name';
  userType = 'user type';
  requestTitle = 'request title';
  requestContent = 'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Autem, minus dolores. Obcaecati suscipit quisquam labore laborum reiciendis alias nemo inventore quasi beatae fugit iure quis nulla iusto quo nihil soluta deserunt veritatis, corporis animi tempora.';

  constructor() { }

  ngOnInit(): void {
    if(this.requestContent.length > 30) { 
      this.textOverflow = true;
    }
  }
}
