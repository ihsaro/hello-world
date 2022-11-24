import {NgModule} from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExampleComponent } from './example.component';
import { ExampleRoutes } from './example.routing';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { NewExampleComponent } from './new-example/new-example.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NewExampleGridComponent } from './new-example-grid/new-example-grid.component';



@NgModule({
  declarations: [
    ExampleComponent,
    NewExampleComponent,
    NewExampleGridComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(ExampleRoutes),
    SharedModule,
    ReactiveFormsModule
  ]
})
export class ExampleModule {}
