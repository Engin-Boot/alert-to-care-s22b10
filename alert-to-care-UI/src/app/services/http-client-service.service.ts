import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Alert } from '../nurse/nurse-home/nurse-home.component';
import { Observable } from 'rxjs';

export class BedDetails{
  bedId:string;
  wardNumber:string;
  patientId:number;
  bedInRow:number;
  bedInColumn:number;
}

@Injectable({
  providedIn: 'root'
})
export class HttpClientServiceService {
  
  
  constructor(
    private httpClient:HttpClient
  ) { }
  public getBedsInformation(wardId:string){
    return this.httpClient.get<BedDetails[]>("http://localhost:64868/IcuLayout/getBedsInformation/"+wardId);
  }
  public allotBedToPatient(wardId:string,bedId:string,Patient:any){
    return this.httpClient.post<any>("http://localhost:64868/PatientData/allocateBed/"+wardId+"/"+bedId,Patient);
  }
  public dischargePatient(patientId:number){
    return this.httpClient.delete<any>("http://localhost:64868/PatientData/BedAllocation/"+patientId);
  }
  public getAllAlerts(wardId:string){
    var alerts = this.httpClient.get<Alert[]>("http://localhost:64868/MedicalDevice/getAlertInfo/"+wardId);
    return alerts;
  }
  public alertOff(bedId:string){
    return this.httpClient.delete<any>("http://localhost:64868/MedicalDevice/Alert/"+bedId);
  }
}