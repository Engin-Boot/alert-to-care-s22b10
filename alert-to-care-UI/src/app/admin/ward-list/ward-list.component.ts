import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { getService } from 'src/app/services/getUsers.service';
import { Wards } from 'src/app/ward';

@Component({
  selector: 'ward-list-comp',
  templateUrl: './ward-list.component.html',
  styleUrls: ['./ward-list.component.css']
})
export class WardListComponent implements OnInit {

  constructor(private http:HttpClient) { }

  columns = ["Ward Id","Number of Beds","Department"];
  index = ["wardNumber","totalBed","department"];

  wards : Wards[] = [];

  ngOnInit(): void {
    
    this.http.get<Wards[]>("http://localhost:64868/IcuLayout/wardDetail").subscribe(
      (response)=>
      {
        this.wards = response;
        console.log(this.wards);
      },
      (error)=>
      {
        console.log(error);
      }
    )
  }
}
