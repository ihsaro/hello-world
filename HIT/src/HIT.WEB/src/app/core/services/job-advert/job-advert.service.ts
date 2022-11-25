import { Injectable } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Observable, tap, BehaviorSubject, of, map } from 'rxjs';
import { JobPosting } from 'src/app/shared/models/JobPosting';
import { JobAdvertApiService } from './job-adverts-api.service';
import { JobPostingWithEnum } from 'src/app/shared/models/JobPostingWithEnumName';
import { JobLocation } from 'src/app/shared/enum/JobLocation.enum';
import { JobType } from 'src/app/shared/enum/JobType.enum';
import { AddJobFormComponent } from 'src/app/job-advert/components/add-job-form/add-job-form.component';
import { CreateJobPosting } from 'src/app/shared/models/CreateJobPosting';
import { JobStatus } from 'src/app/shared/enum/JobStatus.enum.';
import { ToasterService } from '../toaster.service';

@Injectable({
  providedIn: 'root'
})
export class JobAdvertService {
  constructor(private api: JobAdvertApiService, private toastr: ToasterService){}
  
  private jobPostings$$ = new BehaviorSubject<JobPostingWithEnum[]>([]);
  jobPostings$ = this.jobPostings$$.asObservable();

  addJobPosting(newJobPosting: CreateJobPosting, dialog: MatDialogRef<AddJobFormComponent>) {
    return this.api.create(newJobPosting).pipe(
      tap((res : any) => {
        let job: JobPostingWithEnum = {description: res.description, jobStatus: JobStatus[res.jobStatus], title: res.title, yearsOfExperience: res.yearsOfExperience, jobSkills: res.jobSkills , jobLocation: JobLocation[res.jobLocation], jobtype: JobType[res.jobType]}
        this.jobPostings$$.next([job, ...this.jobPostings$$.getValue()])
        dialog.close();
        this.toastr.success("Job advert successfully created!!!")
      })
    ).subscribe();
  }

  loadJobPosting(): Observable<JobPostingWithEnum[]> {
    return this.api.GetAll().pipe(
      map((res: JobPosting[]) => {
        let jobsWithEnums: JobPostingWithEnum[] = res.map((res: JobPosting) => {
          let job: JobPostingWithEnum = {...res, jobLocation: JobLocation[res.jobLocation],jobStatus: JobStatus[res.jobStatus],  jobtype: JobType[res.jobType]};
    return job;
        })
        return jobsWithEnums;
      }),
      tap((res: JobPostingWithEnum[]) => {
        this.jobPostings$$.next(res)
      })
    )
  }

  // editJobPosting(updatedJobPosting: JobPosting): Observable<JobPosting> {
  //   return this.api.update(updatedJobPosting).pipe(
  //     tap(() => {
  //       const allJobPostings = this.JobPostings$$.getValue();
  //       const index = allJobPostings.findIndex((JobPosting) => JobPosting.id == updatedJobPosting.id);
  //       allJobPostings[index] = updatedJobPosting;
  //       this.JobPostings$$.next([...allJobPostings]);
  //       this.toaster.success("JobPosting successfully updated");
  //     })
  //   )
  // }

  // deleteJobPosting(id: number): Observable<JobPosting> {
  //   return this.api.delete(id).pipe(
  //     tap(() => {
  //       const allJobPostings = this.JobPostings$$.getValue();
  //       const index = allJobPostings.findIndex((JobPosting) => JobPosting.id == id);
  //       allJobPostings.splice(index, 1)
  //       this.JobPostings$$.next([...allJobPostings]);
  //       this.toaster.success("JobPosting successfully deleted");
  //     })
  //   )
  // }

}
