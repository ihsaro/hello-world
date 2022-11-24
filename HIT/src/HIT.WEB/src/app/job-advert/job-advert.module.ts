import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { JobAdvertComponent } from './job-advert.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { JobAdvertRoutes } from './job-advert.routing';
import { AddJobFormComponent } from './add-job-form/add-job-form.component';



@NgModule({
  declarations: [
    JobAdvertComponent,
    AddJobFormComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(JobAdvertRoutes),
    SharedModule,
    ReactiveFormsModule
  ]
})
export class JobAdvertModule { }
