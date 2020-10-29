import { Component, OnInit } from '@angular/core';
import { addWardService } from 'src/app/services/addWard.service';

@Component({
  selector: 'ward-comp',
  templateUrl: './ward.component.html',
  styleUrls: ['./ward.component.css']
})
export class WardComponent implements OnInit {

  constructor(private wardAdd:addWardService) { }

  wardNumber:string;
  department:string;
  columns:number;
  rows:number = 2; 
  

  ngOnInit(): void {
  }

  addWard()
  {
    let ward = {WardNumber:this.wardNumber,NumberOfBed:(this.columns)*2,Department:this.department,NumberOfRow:this.rows,NumberOfColumns:this.columns}
    console.log(ward);
    this.wardAdd.addWard(ward).subscribe(
      (response)=>
      {
        console.log(response);
      },
      (error)=>{
        console.log(error);
      }
    )
    alert("Ward Added");
  }
}

