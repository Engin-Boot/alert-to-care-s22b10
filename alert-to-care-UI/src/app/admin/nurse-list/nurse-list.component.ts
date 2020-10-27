import { Component, OnInit } from '@angular/core';
import { getService } from 'src/app/services/getUsers.service';
import { Users } from 'src/app/users';


@Component({
  selector: 'nurse-list-comp',
  templateUrl: './nurse-list.component.html',
  styleUrls: ['./nurse-list.component.css']
})
export class NurseListComponent implements OnInit {

  constructor(private getService:getService) { }

  columns = ["Nurse Id","Ward Id","Name",];
  index = ["nurseId","wardId","nurseName"];

  users : Users[] = [];
  
  ngOnInit(): void {
    this.getService.getUser().subscribe
    (
      (response)=>
      {
        this.users = response;
        console.log(this.users)
      },
      (error)=> console.log(error)
    )
  }
  }
