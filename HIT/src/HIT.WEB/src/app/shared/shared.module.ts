import { NgModule } from '@angular/core';

import { MenuItems } from './menu-items/menu-items';
import { AccordionAnchorDirective, AccordionLinkDirective, AccordionDirective } from './accordion';
import { MaterialModule } from '../material-module';
import { SpinnerComponent } from './spinner/spinner.component';
import { CommonModule } from '@angular/common';


@NgModule({
  declarations: [
    AccordionAnchorDirective,
    AccordionLinkDirective,
    AccordionDirective,
    SpinnerComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    AccordionAnchorDirective,
    AccordionLinkDirective,
    AccordionDirective,
    MaterialModule,
    SpinnerComponent
   ],
  providers: [ MenuItems ]
})
export class SharedModule { }
