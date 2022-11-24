import {NgModule} from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SkillComponent } from './skill.component';
import { AddSkillFormComponent } from './add-skill-form/add-skill-form.component';
import { SkillRoutes } from './skill.routing';



@NgModule({
  declarations: [
    SkillComponent,
    AddSkillFormComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(SkillRoutes),
    SharedModule,
    ReactiveFormsModule
  ]
})
export class SkillModule {}
