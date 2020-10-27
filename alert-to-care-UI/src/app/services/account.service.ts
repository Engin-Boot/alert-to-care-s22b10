import { Injectable } from "@angular/core";
import {HttpClient} from '@angular/common/http'
import { Inject } from '@angular/core';

@Injectable()
export class AccountService {

    httpClient:HttpClient;
    baseUrl:string;

    constructor(httpClient:HttpClient,@Inject('apiBaseAddress')baseUrl:string)
    {
        this.baseUrl=baseUrl;
        this.httpClient=httpClient;
    }

    login(user)
        {
            return this.httpClient.post(`${this.baseUrl}/api/NurseData/validate`,user,{responseType: 'text'});
            
        }

}