import { Component, OnInit } from '@angular/core';
import { LirService } from 'src/app/lir.service';
import { ConsumerProfile } from 'src/app/models/ConsumerProfile';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  consumerList: ConsumerProfile[] = [];
  dtOptions: DataTables.Settings = {};

  constructor(
    private appService: LirService
  ) { }

  ngOnInit(): void {
    this.loadList();
    // this.dtOptions = {
    //   searching: true,
    //   lengthChange: true,
    //   pageLength: 10
    // };
  }

  loadList(){
    this.appService.getAllHistory().subscribe(res =>{
      this.consumerList = res;
    })
  }

}
