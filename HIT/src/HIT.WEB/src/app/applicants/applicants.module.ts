import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ApplicantsRoutingModule } from './applicants-routing.module';
import { ApplicantsComponent } from './applicants/applicants.component';
import { MaterialModule } from '../material-module';
import { MaterialComponentsModule } from "../material-component/material.module";
import { SharedModule } from '../shared/shared.module';
import { ContractApplicantTableComponent } from './applicant-table/applicant-contract-table.component';
import { HrApplicantTableComponent } from './applicant-table/applicant-hr-table.component';
import { TechApplicantTableComponent } from './applicant-table/applicant-tech-table.component';
import { RejectApplicantTableComponent } from './applicant-table/applicant-reject-table.component';
import { EntryApplicantTableComponent } from './applicant-table/applicant-entry-table.component';
import { ContractComponent } from './contract/contract.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ApplicantsViewComponent } from './applicants-view/applicants-view.component';
import {MatChipsModule} from '@angular/material/chips';

@NgModule({
    declarations: [
        ApplicantsComponent,
        ContractApplicantTableComponent,
        HrApplicantTableComponent,
        TechApplicantTableComponent,
        RejectApplicantTableComponent,
        EntryApplicantTableComponent,
        ContractComponent,
        ApplicantsViewComponent
    ],
    imports: [
        CommonModule,
        ApplicantsRoutingModule,
        MaterialModule,
        MaterialComponentsModule,
        SharedModule,
        ReactiveFormsModule,
        FormsModule
    ]
})
export class ApplicantsModule { }
