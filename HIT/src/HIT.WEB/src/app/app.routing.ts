import { Routes } from '@angular/router';

import { FullComponent } from './layouts/full/full.component';

export const AppRoutes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      {
        path: '',
        redirectTo: '/example',
        pathMatch: 'full'
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
      }
    ]
  }
];
