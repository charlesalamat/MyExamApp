import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LirService } from 'src/app/lir.service';

@Component({
  selector: 'app-setup',
  templateUrl: './setup.component.html',
  styleUrls: ['./setup.component.css']
})
export class SetupComponent implements OnInit {

  setupForm = new FormGroup({
    id:new FormControl(null),
    guaranteedIssue: new FormControl(0, Validators.required),
    maxAgeLimit: new FormControl(0, Validators.required),
    minAgeLimit: new FormControl(0, Validators.required),
    minimumRange: new FormControl(0, Validators.required),
    maximumRange: new FormControl(0, Validators.required),
    increments: new FormControl(0, Validators.required)
  });

  GuaranteedIssue: number = 0;
  MaxAgeLimit: number = 0;
  MinAgeLimit: number = 0;
  MinimumRange: number = 0;
  MaximumRange: number = 0;
  Increments: number = 0;
  
  constructor(
    private appService: LirService
  ) { }

  ngOnInit(): void {
    this.loadConfig();
  }

  loadConfig(){
    this.appService.getRetirementSetup().subscribe(res =>{
      console.log(res);
      this.setupForm.patchValue(res);
    });
  }

  onSubmit(form: any){
    this.appService.configureSetup(form.value).subscribe(res=>{
      this.loadConfig();
    });
  }

}
