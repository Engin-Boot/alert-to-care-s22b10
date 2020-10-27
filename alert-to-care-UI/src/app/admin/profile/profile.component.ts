import { Component, OnInit } from '@angular/core';
import { addNurseService } from 'src/app/services/addNurse.service';

@Component({
  selector: 'profile-comp',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private addNurse:addNurseService) { }

NurseId:string;
WardId:string;
Name:string;

  ngOnInit(): void {
  }

  addProfile()
    {
      let profile = {nurseId:this.NurseId,wardId:this.WardId,nurseName:this.Name};
      this.addNurse.addNurse(profile).subscribe(
        (response) =>
        {
          console.log(response);
        },
        (error)=>{
          console.log(error)
        }
      )
      
      alert("Profile Added");
    }
}
