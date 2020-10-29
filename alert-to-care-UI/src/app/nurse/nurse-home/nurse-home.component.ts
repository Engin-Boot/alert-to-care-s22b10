import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {HttpClientServiceService,BedDetails} from "../../services/http-client-service.service"

export class BedCard{
  bedId:string;
  row:number;
  column:number;
  allotmentStatus:string;
  cardType:string;
  patientId:number;
  buttonName:string;
  disableAlert:boolean;
  functionName:string;
}
export class Alert{
  bedId:string;
  device:string;
  value:number;
}

@Component({
  selector: 'nurse-home-comp',
  templateUrl: './nurse-home.component.html',
  styleUrls: ['./nurse-home.component.css']
})
export class NurseHomeComponent implements OnInit {
  BedDetailsArray:BedDetails[];
  BedCardArray:Array<BedCard>=[];
  BedCardMatrix:Array<BedCard[]>=[];
  AlertDetails:Array<Alert>=[];
  NurseName:string;
  wardId:string;
  interval:any;

getalertFunc():void {
  this.httpClientService.getAllAlerts(this.wardId).subscribe(
    response =>this.handleSuccessfulGetAlertResponse(response),
   );
}
  constructor(
    private httpClientService:HttpClientServiceService,
    private route : ActivatedRoute,
    private router: Router) { 
    this.httpClientService.getBedsInformation(this.wardId).subscribe(
      response =>this.handleSuccessfulGetBedResponse(response),
     );
     this.interval =setInterval(() => { this.getalertFunc(); }, 1000);
  }

  ngOnInit(): void {
    
    this.httpClientService.getAllAlerts(this.wardId).subscribe(
      response =>this.handleSuccessfulGetAlertResponse(response),
     );
     this.route.queryParams.subscribe(params => {
      this.NurseName = params['Name'];
      this.wardId = params['wardId']
    });

  }
  handleSuccessfulGetBedResponse(response)
  {
      this.BedDetailsArray=response;
      this.createBedCards();    
  }
  handleSuccessfulGetAlertResponse(response)
  {
    this.AlertDetails=response;
    console.log(this.AlertDetails);
    for(let i = 0; i < this.BedCardMatrix.length; i++) {
  
      for(let j = 0; j < this.BedCardMatrix[i].length; j++) {
       var check = this.AlertDetails.find(x=>x.bedId == this.BedCardMatrix[i][j].bedId);
         if(check)
         {
           
           this.BedCardMatrix[i][j].disableAlert=false;
           this.BedCardMatrix[i][j].cardType="ColorCodeCardAlert";
         }
      }
   }
   console.log(this.BedCardMatrix);
  }
  createBedCards():void{
      
      for (let index = 0; index < this.BedDetailsArray.length; index++) {
        var bedCard = new BedCard();
        bedCard.bedId=this.BedDetailsArray[index].bedId;
        bedCard.row=this.BedDetailsArray[index].bedInRow;
        bedCard.column=this.BedDetailsArray[index].bedInColumn;
        bedCard.disableAlert=true;
        if(this.BedDetailsArray[index].patientId == null)
        {
          bedCard.allotmentStatus="PatientBedCardEmpty";
          bedCard.cardType = "ColorCodeCardEmpty";
          bedCard.patientId = null;
          bedCard.buttonName = "ADMIT";
          bedCard.functionName='onAddPatient';

        }
        else{
          bedCard.patientId=this.BedDetailsArray[index].patientId;
          bedCard.allotmentStatus="PatientBedCardOkay";
          bedCard.cardType = "ColorCodeCardOkay";
          bedCard.buttonName = "DISCHARGE";
          bedCard.functionName="onDischarge";
        }
        this.BedCardArray.push(bedCard);
      }
      this.BedCardMatrix=this.splitArray(this.BedCardArray,this.BedCardArray.length/2);
  }
  splitArray(array:Array<BedCard>, part:number) {
    var tmp = [];
    for(var i = 0; i < array.length; i += part) {
        tmp.push(array.slice(i, i + part));
    }
    return tmp;
  }
  onDischarge(event:any,bedId:string):void{
    if(confirm("Are you sure to discharge")) {
      console.log("Patient Discharged");
      var patient = this.BedCardArray.find(x=>x.bedId == bedId);
      this.httpClientService.dischargePatient(patient.patientId).subscribe(
        response =>this.handleSuccessfulDischargeResponse(response,bedId),
       ); 
    }
  }
  handleSuccessfulDischargeResponse(response,bedId){
    for(let i = 0; i < this.BedCardMatrix.length; i++) {
  
      for(let j = 0; j < this.BedCardMatrix[i].length; j++) {
         if(bedId == this.BedCardMatrix[i][j].bedId)
         {
           
           this.BedCardMatrix[i][j].allotmentStatus="PatientBedCardEmpty";
           this.BedCardMatrix[i][j].cardType="ColorCodeCardEmpty";
           this.BedCardMatrix[i][j].buttonName="ADMIT";
           this.BedCardMatrix[i][j].functionName='onAddPatient';
           this.BedCardMatrix[i][j].patientId = null;
         }
      }
   }
    this.router.navigate(['/nurse/Jane']);
  }
  onAlertOff(event:any,bedId:string):void{
    if(confirm("Are you sure to turn off alert")) {
      console.log("Alert turned off");
      this.httpClientService.alertOff(bedId).subscribe(
        response =>this.handleSuccessfulAlertOffResponse(response,bedId),
       ); 
    }
  }
  handleSuccessfulAlertOffResponse(response,bedId){
    for(let i = 0; i < this.BedCardMatrix.length; i++) {
  
      for(let j = 0; j < this.BedCardMatrix[i].length; j++) {
         if(bedId == this.BedCardMatrix[i][j].bedId)
         {
          this.BedCardMatrix[i][j].disableAlert=true;
          this.BedCardMatrix[i][j].cardType="ColorCodeCardOkay";
           
         }
      }
    }
    this.router.navigate(['/nurse/Jane']);
  }
  onAddPatient(event:any,bedId:string):void{
    if(confirm("Are you sure")) {
      this.router.navigate([ '/addpatient' ],{ queryParams: { bedId: bedId ,wardId:this.wardId} });
    }

  }

}