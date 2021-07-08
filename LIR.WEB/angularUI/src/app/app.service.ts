import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ConsumerProfile } from './models/ConsumerProfile';
import { RetirementSetup } from './models/RetirementSetup';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  
  apiURL = 'https://localhost:44319/';

  constructor(
    private http: HttpClient
  ) { }

  requestCompute(consumerProfile: any): Observable<ConsumerProfile>{
    return this.http.post<ConsumerProfile>(this.apiURL + 'api/Benefit/compute', consumerProfile);
  }

  getRetirementSetup(): Observable<RetirementSetup>{
    return this.http.get<RetirementSetup>(this.apiURL + 'api/Benefit/getSetup');
  }

  configureSetup(retirementSetup: any): Observable<RetirementSetup>{
    return this.http.post<RetirementSetup>(this.apiURL + 'api/Benefit/configureSetup', retirementSetup);
  }
}
