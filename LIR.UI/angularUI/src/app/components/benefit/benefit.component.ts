import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LirService } from 'src/app/lir.service';
import { ConsumerBenefitResult } from 'src/app/models/ConsumerBenefitResult';

@Component({
  selector: 'app-benefit',
  templateUrl: './benefit.component.html',
  styleUrls: ['./benefit.component.css']
})
export class BenefitComponent implements OnInit {

  consumerForm = new FormGroup({
    ConsumerName: new FormControl('', Validators.required),
    BasicSalary: new FormControl(null, Validators.required),
    Birthdate: new FormControl(null, Validators.required)
  });
  
  consumerBenefitResult: ConsumerBenefitResult[] = [];

  constructor(
    private appService: LirService
  ) { }

  ngOnInit(): void {
    console.log(this.consumerBenefitResult);
  }

  onSubmit(form: any){
    this.appService.requestCompute(form.value).subscribe(res => {
      this.consumerForm.patchValue(res);
      this.consumerBenefitResult = res.consumerBenefitResults;
    });
  }

  onReset(){
    this.consumerForm.reset;
    this.consumerForm.get('ConsumerName')?.setValue('');
    this.consumerForm.get('BasicSalary')?.setValue(null);
    this.consumerForm.get('Birthdate')?.setValue(null);
    this.consumerBenefitResult = [];
  }

}
