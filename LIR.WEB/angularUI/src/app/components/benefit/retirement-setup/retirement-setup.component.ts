import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AppService } from 'src/app/app.service';
import { RetirementSetup } from 'src/app/models/RetirementSetup';

@Component({
  selector: 'app-retirement-setup',
  templateUrl: 'retirement-setup.component.html',
  styles: [
  ]
})
export class RetirementSetupComponent implements OnInit {

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
    private appService: AppService,
    private modalService: NgbModal
  ) { }

  ngOnInit(): void {
    this.loadConfig();
  }

  loadConfig(){
    this.appService.getRetirementSetup().subscribe(res =>{
      this.GuaranteedIssue = res.guaranteedIssue;
      this.MaxAgeLimit = res.maxAgeLimit;
      this.MinAgeLimit = res.minAgeLimit;
      this.MinimumRange = res.minimumRange;
      this.MaximumRange = res.maximumRange;
      this.Increments = res.increments
    });
  }

  openModal(content: any){
    this.appService.getRetirementSetup().subscribe(res =>{
      this.setupForm.patchValue(res);
    });
    this.modalService.open(content);
  };

  onSubmit(form: any){
    this.appService.configureSetup(form.value).subscribe(res=>{
      this.loadConfig();
      this.modalService.dismissAll();
    });
  }

}
