import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicantsViewComponent } from './applicants-view.component';

describe('ApplicantsViewComponent', () => {
  let component: ApplicantsViewComponent;
  let fixture: ComponentFixture<ApplicantsViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApplicantsViewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ApplicantsViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
