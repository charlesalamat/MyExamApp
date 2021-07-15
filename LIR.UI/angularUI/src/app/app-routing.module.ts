import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BenefitComponent } from './components/benefit/benefit.component';
import { HistoryEditComponent } from './components/history/history-edit/history-edit.component';
import { HistoryComponent } from './components/history/history.component';
import { SetupComponent } from './components/setup/setup.component';

const routes: Routes = [
  {path:'benefit', component: BenefitComponent},
  {path:'history', component: HistoryComponent},
  {path:'history-edit/:id', component: HistoryEditComponent},
  {path:'setup', component: SetupComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
