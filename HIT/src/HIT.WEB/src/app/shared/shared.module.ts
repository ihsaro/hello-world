import { NgModule } from '@angular/core';

import { MenuItems } from './menu-items/menu-items';
import { AccordionAnchorDirective, AccordionLinkDirective, AccordionDirective } from './accordion';
import { MaterialModule } from '../material-module';
import { SpinnerComponent } from './spinner/spinner.component';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
import {MatTabsModule} from '@angular/material/tabs';
import { MatChipsModule } from '@angular/material/chips';

@NgModule({
  declarations: [
    AccordionAnchorDirective,
    AccordionLinkDirective,
    AccordionDirective,
    SpinnerComponent,
    LoaderComponent,

  ],
  imports: [
    CommonModule,
    MaterialModule,
    MatTabsModule
  ],
  exports: [
    AccordionAnchorDirective,
    AccordionLinkDirective,
    AccordionDirective,
    MaterialModule,
    MatChipsModule,
    SpinnerComponent,
    LoaderComponent
   ],
  providers: [ MenuItems ]
})
export class SharedModule { }
