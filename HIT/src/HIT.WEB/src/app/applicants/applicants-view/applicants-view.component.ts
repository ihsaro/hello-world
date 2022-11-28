import { Component, Inject, OnInit } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { NewExampleGridComponent } from 'src/app/example/new-example-grid/new-example-grid.component';
import { JobApplication } from 'src/app/shared/models/jobApplication';

@Component({
  selector: 'app-applicants-view',
  templateUrl: './applicants-view.component.html',
  styleUrls: ['./applicants-view.component.css']
})
export class ApplicantsViewComponent implements OnInit {

  exampleForm = this.fb.group({
    name: [ this.data.Candidate.firstName + " " +  this.data.Candidate.lastName || "" , [Validators.required]],
    age: ['', [Validators.required]],
    address: ['', [Validators.required]],
  })

  constructor(@Inject(MAT_DIALOG_DATA) public data: JobApplication , private fb:FormBuilder, private dialogRef: MatDialogRef<ApplicantsViewComponent>) { }

  ngOnInit(): void {
    console.log(this.data)
  }

}
