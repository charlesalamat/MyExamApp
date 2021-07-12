import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
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
  
  modalTitle = "";

  consumerForm = new FormGroup({
    ConsumerName: new FormControl('', Validators.required),
    BasicSalary: new FormControl(null, Validators.required),
    Birthdate: new FormControl(null, Validators.required)
  });

  consumerRecord: ConsumerProfile = new ConsumerProfile;
  consumerRequestDates: Date[]=[];

  constructor(
    private appService: AppService,
    private modalService: NgbModal
  ) { }

  ngOnInit(): void {
  }

  onSubmit(form: any, content: any){
    this.appService.requestCompute(form.value).subscribe(res =>{
      this.consumerRecord = res;
      this.consumerRequestDates = [...new Set(res.consumerBenefitResults.map(item => item.transactionDateTime))]
    });
    this.modalTitle = "Computation Result";
    this.modalService.open(content, { size: 'lg' });
  }

  onViewHistory(form: any, content: any){
    this.appService.viewMyHistory(form.value.ConsumerName).subscribe(res =>{
      console.log(res);
      if(res.consumerBenefitResults != null){
        this.consumerRecord = res;
        this.consumerRequestDates = [...new Set(res.consumerBenefitResults.map(item => item.transactionDateTime))]
        this.modalTitle = "Computation History";
        this.modalService.open(content, { size: 'lg' });
      }
    });
  }

  getRecordByTransaction(dataTime: any){
    return this.consumerRecord.consumerBenefitResults.filter(x => x.transactionDateTime == dataTime);
  }

  onReset(){
    this.consumerForm.reset;
    this.consumerForm.get('ConsumerName')?.setValue('');
    this.consumerForm.get('BasicSalary')?.setValue(null);
    this.consumerForm.get('Birthdate')?.setValue(null);
  }
}
