import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from "@angular/core";


@Injectable()

export class addNurseService {

    constructor(private http:HttpClient) {}

    url:string = "http://localhost:64868/api/NurseData/AddNurse";

   

   addNurse(nurse)
        {
            return this.http.post(this.url,nurse);            
        }

}