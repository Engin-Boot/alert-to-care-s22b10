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
  beds:string;
  department:string;
  
  

  ngOnInit(): void {
  }

  addWard()
  {
    let ward = {WardNumber:this.wardNumber,TotalBed:this.beds,Department:this.department}
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
