import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidatesComponent } from './candidates.component';

export const candidateRoutes: Routes = [{
  path: '',
  component: CandidatesComponent
}];
