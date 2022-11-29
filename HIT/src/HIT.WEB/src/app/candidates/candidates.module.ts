import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CandidatesComponent } from './candidates.component';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { candidateRoutes } from './candidates-routing.module';
import { MaterialModule } from '../material-module';
import {MatPaginatorModule} from '@angular/material/paginator';

@NgModule({
  declarations: [
    CandidatesComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(candidateRoutes),
    SharedModule,
    ReactiveFormsModule,
    MaterialModule,
    MatPaginatorModule,
    
  ]
})
export class CandidatesModule { }
