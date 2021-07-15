import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ConsumerProfile } from './models/ConsumerProfile';
import { RetirementSetup } from './models/RetirementSetup';

@Injectable({
  providedIn: 'root'
})
export class LirService {
  apiURL = 'https://localhost:44314/';
  constructor(
    private http: HttpClient
  ) { }

  requestCompute(consumerProfile: any): Observable<ConsumerProfile>{
    return this.http.post<ConsumerProfile>(this.apiURL + 'api/Benefit/compute', consumerProfile);
  }

  viewMyHistory(consumerName: any): Observable<ConsumerProfile>{
    return this.http.get<ConsumerProfile>(this.apiURL + 'api/Benefit/viewmyhistory?consumerName=' + consumerName);
  }

  getRetirementSetup(): Observable<RetirementSetup>{
    return this.http.get<RetirementSetup>(this.apiURL + 'api/Benefit/getSetup');
  }

  configureSetup(retirementSetup: any): Observable<RetirementSetup>{
    return this.http.post<RetirementSetup>(this.apiURL + 'api/Benefit/configureSetup', retirementSetup);
  }

  getAllHistory(): Observable<ConsumerProfile[]>{
    return this.http.get<ConsumerProfile[]>(this.apiURL + 'api/Benefit/history');
  }
  
  getHistory(id: any): Observable<ConsumerProfile>{
    return this.http.get<ConsumerProfile>(this.apiURL + 'api/Benefit/historyEdit?id=' + id);
  }

  postHistory(consumer: any): Observable<ConsumerProfile>{
    return this.http.post<ConsumerProfile>(this.apiURL + 'api/Benefit/historyEdit', consumer);
  }
  
}
