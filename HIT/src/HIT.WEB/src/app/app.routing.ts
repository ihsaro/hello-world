import { Routes } from '@angular/router';

import { FullComponent } from './layouts/full/full.component';

export const AppRoutes: Routes = [
  {
    path: 'dashboard',
    component: FullComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('./dashboard/dashboard.module').then(m => m.DashboardModule),
      },
      {
        path: '',
        loadChildren:
          () => import('./material-component/material.module').then(m => m.MaterialComponentsModule)
      },
      {
        path: 'example',
        loadChildren: () => import('./example/example.module').then(m => m.ExampleModule)
      },
      {
        path: 'skill',
        loadChildren: () => import('./skill/skill.module').then(m => m.SkillModule)
      },
      {
        path: 'job-adverts',
        loadChildren: () => import('./job-advert/job-advert.module').then(m => m.JobAdvertModule)
      },
      {
        path: 'candidates',
        loadChildren: () => import('./candidates/candidates.module').then(m => m.CandidatesModule)
      },
      {
        path: 'job/:id/applicants',
        loadChildren: () => import('./applicants/applicants.module').then(m => m.ApplicantsModule)
      }
    ],
  },
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  },
  {
    path: 'login',
    loadChildren: () => import('./login/login.module').then(m => m.LoginModule),
  }
];
