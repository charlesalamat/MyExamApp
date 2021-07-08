import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { AppService } from 'src/app/app.service';
import { ConsumerBenefitResult } from 'src/app/models/ConsumerBenefitResult';
import { ConsumerProfile } from 'src/app/models/ConsumerProfile';

@Component({
  selector: 'app-benefit',
  templateUrl: 'benefit.component.html',
  styles: [
  ]
})
export class BenefitComponent implements OnInit {
  
  consumerForm = new FormGroup({
    ConsumerName: new FormControl('', Validators.required),
    BasicSalary: new FormControl(0, Validators.required),
    Birthdate: new FormControl(null, Validators.required)
  });

  consumerRecord: ConsumerProfile = new ConsumerProfile;
  consumerRequestDates: Date[]=[];

  constructor(
    private appService: AppService
  ) { }

  ngOnInit(): void {
  }

  onSubmit(form: any){
    console.log(form);
    this.appService.requestCompute(form.value).subscribe(res =>{
      this.consumerRecord = res;
      this.consumerRequestDates = [...new Set(res.consumerBenefitResults.map(item => item.transactionDateTime))]
    });
  }

  getRecordByTransaction(dataTime: any){
    return this.consumerRecord.consumerBenefitResults.filter(x => x.transactionDateTime == dataTime);
  }
}
