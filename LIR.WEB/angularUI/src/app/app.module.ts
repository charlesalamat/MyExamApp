import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppService } from './app.service';
import { BenefitComponent } from './components/benefit/benefit.component';
import { RetirementSetupComponent } from './components/benefit/retirement-setup/retirement-setup.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DataTablesModule } from 'angular-datatables';
import { OrderByModule } from 'ng-orderby-pipe';

@NgModule({
  declarations: [
    AppComponent,
    BenefitComponent,
    RetirementSetupComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbModule,
    DataTablesModule,
    OrderByModule
  ],
  providers: [AppService],
  bootstrap: [AppComponent]
})
export class AppModule { }
