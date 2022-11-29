import { Component, Inject, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CommentApiService } from 'src/app/core/services/skills/comments.service';
import { CandidateType } from 'src/app/shared/enum/CandidateType';
import { JobApplication } from 'src/app/shared/models/jobApplication';

@Component({
  selector: 'app-applicants-view',
  templateUrl: './applicants-view.component.html',
  styleUrls: ['./applicants-view.component.css']
})
export class ApplicantsViewComponent implements OnInit {
  com = new FormControl('');
  applicantForm = this.fb.group({
    name: [ "" ,  [Validators.required]],
    location: ['', [Validators.required]],
    type: ['', [Validators.required]],
    email: ['', [Validators.required]],
    years: [0, [Validators.required]],
    matchRate: [0, [Validators.required]],
    skills: [[{skill: '', id: 0}], [Validators.required]]
  })

  constructor(private fb:FormBuilder, private dialogRef: MatDialogRef<ApplicantsViewComponent>, public comment: CommentApiService, @Inject(MAT_DIALOG_DATA) public data: {data: JobApplication}) { }

  ngOnInit(): void {
    this.comment.loadComment(this.data.data.id!).subscribe();
    this.applicantForm.disable();
    this.applicantForm.patchValue({"name": this.data.data.candidate.firstName + ' ' + this.data.data.candidate.lastName,
    "location": this.data.data.candidate.candidateLocation,
    "type": CandidateType[this.data.data.candidate.candidateType],
    "email": this.data.data.candidate.emailAddress,
    "years": this.data.data.candidate.yearsOfExperience,
    "matchRate": this.data.data.matchRate,
    "skills": this.data.data.candidate.candidateSkills,
  });
  }

  userComment() {
    this.comment.addComment(this.data.data.id!, this.com.getRawValue()!).subscribe()
    console.log(this.com.getRawValue())
    this.com.reset();
  }

}
