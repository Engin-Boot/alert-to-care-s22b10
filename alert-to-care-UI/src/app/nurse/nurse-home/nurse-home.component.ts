import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {HttpClientServiceService,BedDetails} from '../../http-client-service.service';
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
  wardId:string;
  
  constructor(
    private httpClientService:HttpClientServiceService,
    private route : ActivatedRoute,
    private router: Router) { 
    this.wardId="5";
    this.httpClientService.getBedsInformation(this.wardId).subscribe(
      response =>this.handleSuccessfulGetBedResponse(response),
     );
  }

  ngOnInit(): void {
    
    this.httpClientService.getAllAlerts(this.wardId).subscribe(
      response =>this.handleSuccessfulGetAlertResponse(response),
     );

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
        response =>this.handleSuccessfulDischargeResponse(response),
       ); 
    }
  }
  handleSuccessfulDischargeResponse(response){
    this.router.navigate(['/nurse']);
  }
  onAlertOff(event:any,bedId:string):void{
    if(confirm("Are you sure to turn off alert")) {
      console.log("Alert turned off");
      this.httpClientService.alertOff(bedId).subscribe(
        response =>this.handleSuccessfulAlertOffResponse(response),
       ); 
    }
  }
  handleSuccessfulAlertOffResponse(response){
    this.router.navigate(['/nurse']);
  }
  onAddPatient(event:any,bedId:string):void{
    if(confirm("Are you sure")) {
      console.log("Patient Admitted to Bed :"+bedId);
      this.router.navigate([ '/addpatient' ],{ queryParams: { bedId: bedId ,wardId:this.wardId} });
    }

  }

}
