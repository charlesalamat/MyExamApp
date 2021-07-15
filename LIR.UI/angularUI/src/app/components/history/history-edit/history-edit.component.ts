import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { LirService } from 'src/app/lir.service';
import { ConsumerBenefitResult } from 'src/app/models/ConsumerBenefitResult';

@Component({
  selector: 'app-history-edit',
  templateUrl: './history-edit.component.html',
  styleUrls: ['./history-edit.component.css']
})
export class HistoryEditComponent implements OnInit {

  consumerForm = new FormGroup({
    consumerName: new FormControl('', Validators.required),
    basicSalary: new FormControl(null, Validators.required),
    birthdate: new FormControl(null, Validators.required)
  });
  
  consumerBenefitResult: ConsumerBenefitResult[] = [];
  
  constructor(
    private appService: LirService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const id = String(this.route.snapshot.paramMap.get('id'));
    this.getById(id);
  }

  getById(id: any){
    this.appService.getHistory(id).subscribe(res =>{
      console.log(res);
      this.consumerForm.patchValue(res);
      this.consumerForm.get('birthdate')?.patchValue(this.formatDate(res.birthdate));
      this.consumerBenefitResult = res.consumerBenefitResults;
    })
  }

  onSubmit(form: any){
    this.appService.postHistory(form.value).subscribe(res => {
      this.consumerForm.patchValue(res);
      this.consumerBenefitResult = res.consumerBenefitResults;
    });
  }

  private formatDate(date: any) {
    const d = new Date(date);
    let month = '' + (d.getMonth() + 1);
    let day = '' + d.getDate();
    const year = d.getFullYear();
    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;
    return [year, month, day].join('-');
  }

}
