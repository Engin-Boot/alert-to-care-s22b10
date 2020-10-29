import { Component, Inject, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  loggerService:any;
  accountServiceRef:AccountService;

  constructor(@Inject("logger") loggerService:any,accountServiceRef:AccountService,private route:Router) {
    
    this.loggerService = loggerService;
    this.accountServiceRef = accountServiceRef;

   }
  
  username:string;
  password:string;

  ngOnInit(): void {
    
  }


  onLogin()
  {

    let userName = this.username;
    let user = {NurseName:this.username,WardId:this.password};
    this.accountServiceRef.login(user).subscribe
    (
      (data) =>
      {
        console.log(data);
        if(data == "Validation Succesfull")
          {
            alert("LOGIN SUCCESSFUL");
            this.route.navigate(['/nurse'],{ queryParams: { Name: this.username ,wardId:this.password} });
            console.log("SUCCESS");          
          }
          else if(data == "Admin Login")
            {
              alert("LOGIN SUCCESFUL");
              this.route.navigate(['admin',this.username]);
              console.log("admin login");
            }
        else
          {
            alert("LOGIN FAIL");
          }
      },
      (error)=>{

        console.log(error);
      }
    )
     
  }
  
}
