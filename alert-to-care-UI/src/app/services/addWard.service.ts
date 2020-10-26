import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from "@angular/core";


@Injectable()

export class addWardService {

    constructor(private http:HttpClient) {}

    url:string = "http://localhost:64868/IcuLayout/IcuWardInfo";

   

   addWard(ward)
        {
            return this.http.post(this.url,ward);            
        }

}