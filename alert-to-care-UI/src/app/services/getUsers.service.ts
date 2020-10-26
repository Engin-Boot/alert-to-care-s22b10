import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Injectable } from "@angular/core";
import {Inject } from '@angular/core'
import { Users } from '../users';

@Injectable()

export class getService {

    constructor(private http:HttpClient) {}

    url:string = "http://localhost:64868/api/NurseData";

   

    getUser()
        {
            return this.http.get<Users[]>(this.url);            
        }

}