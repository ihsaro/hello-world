import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ApplicantsComponent } from './applicants/applicants.component';
import {MatDividerModule} from '@angular/material/divider';

const routes: Routes = [{
  path: '',
  component: ApplicantsComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes), MatDividerModule],
  exports: [RouterModule]
})
export class ApplicantsRoutingModule {
  
 }
