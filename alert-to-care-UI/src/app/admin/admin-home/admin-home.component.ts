import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from '@angular/router'
@Component({
  selector: 'admin-home-comp',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})
export class AdminHomeComponent implements OnInit {

  userName:string="";
  constructor(private acr:ActivatedRoute) { }

  ngOnInit(): void {
    this.acr.params.subscribe(
      (params)=>
      {
        this.userName=params.userName;
      }
    );
  }

}
