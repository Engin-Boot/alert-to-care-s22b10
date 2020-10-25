import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup ,NgForm,Validators} from '@angular/forms';
import { ActivatedRoute,Router } from '@angular/router';
import { HttpClientServiceService } from 'src/app/http-client-service.service';

@Component({
  selector: 'nurse-add-patient-comp',
  templateUrl: './nurse-add-patient.component.html',
  styleUrls: ['./nurse-add-patient.component.css']
})
export class NurseAddPatientComponent implements OnInit {
  selectedBedId:string;
  wardId:string;
  PatientForm: FormGroup;
  constructor(private router: Router,private route:ActivatedRoute,private fb: FormBuilder,private httpClientService:HttpClientServiceService,) {
    this.PatientForm = this.fb.group({  
      'PatientId' : [null, Validators.required],  
      'PatientName' : [null, Validators.required],  
      'Address' : [null, Validators.compose([Validators.required, Validators.minLength(30), Validators.maxLength(500)])],  
      'Email':[null, Validators.compose([Validators.required,Validators.email])],  
      'Mobile':[null, Validators.compose([Validators.required])], 
      
    });  
   }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.selectedBedId = params['bedId'];
      this.wardId = params['wardId']
    });
  }
  onAdmit():void{
    console.log(this.PatientForm.value);
    this.httpClientService.allotBedToPatient(this.wardId,this.selectedBedId,this.PatientForm.value).subscribe(
      response =>this.handleSuccessfulResponse(response),
     );
    this.router.navigate(['/nurse']);
  }
  handleSuccessfulResponse(response){

  }
}
