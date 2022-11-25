import { AfterViewInit, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { Router } from '@angular/router';
import { fromEvent, debounceTime, distinctUntilChanged, tap, merge } from 'rxjs';
import { ApplicantsService } from 'src/app/core/services/applicants/applicants.service';
import { ApplicationPhase } from 'src/app/shared/enum/ApplicationPhase';
import { JobApplication } from 'src/app/shared/models/jobApplication';
import { JobPostingWithEnum } from 'src/app/shared/models/JobPostingWithEnumName';
import { HrApplicantDataSource } from 'src/app/core/services/applicants/hr-datasource';
import { JobAdvertApiService } from 'src/app/core/services/job-advert/job-adverts-api.service';

@Component({
  selector: 'app-hr-applicant-table',
  templateUrl: './applicant-table.component.html',
  styleUrls: ['./applicant-table.component.css']
})
export class HrApplicantTableComponent implements OnInit, AfterViewInit {
  datasource!: HrApplicantDataSource;
  displayedColumns: string[] = [ 'No', 'Name', 'Email', 'Location', 'Actions'];
  totalData!: number;
  @Input() userId = 1;

  @ViewChild(MatTable) table! :MatTable<JobApplication>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild('input') input!: ElementRef;

  constructor(public dialog: MatDialog, private  applicationService: ApplicantsService, private router: Router, private jobAppService: JobAdvertApiService) {
  }

  ngOnInit(): void {
    this.datasource = new HrApplicantDataSource(this.applicationService);
    this.datasource.loadJobApplication(this.userId, '', 'asc', 0, 5)
  }

  ngAfterViewInit() {
    fromEvent(this.input.nativeElement,'keyup')
    .pipe( 
        debounceTime(150),
        distinctUntilChanged(),
        tap(() => {
            this.paginator.pageIndex = 0;
            this.loadApplicantsPage;
        })
    )
    .subscribe();

// reset the paginator after sorting
this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

// on sort or paginate events, load a new page
merge(this.sort.sortChange, this.paginator.page)
.pipe(
    tap(() => this.loadApplicantsPage())
)
.subscribe();
  }

  loadApplicantsPage() {
    this.datasource.loadJobApplication(this.userId,  this.input.nativeElement.value,
      this.sort.direction,
      this.paginator.pageIndex,
      this.paginator.pageSize)
}

next(data: JobApplication) {
  this.jobAppService.UpdatePhase(data.id!, 3).subscribe((res) => {
    let jobs: JobApplication[] = this.applicationService.HRapplications$$.value;
    let index = jobs.findIndex((res: JobApplication) => res.id === data.id)
    jobs.splice(index, 1)
    this.applicationService.HRapplications$$.next(jobs)
    this.applicationService.Contractapplications$$.next([data,  ...this.applicationService.HRapplications$$.value])
  })
 
}

back(data: JobApplication) {
  this.jobAppService.UpdatePhase(data.id!, 0).subscribe((res) => {
    let jobs: JobApplication[] = this.applicationService.HRapplications$$.value;
    let index = jobs.findIndex((res: JobApplication) => res.id === data.id)
    jobs.splice(index, 1)
    this.applicationService.HRapplications$$.next(jobs)
    this.applicationService.TECHapplications$$.next([data,  ...this.applicationService.Entryapplications$$.value])
  })
 
}


reject(data: JobApplication) {
  this.jobAppService.UpdatePhase(data.id!, -1).subscribe((res) => {
  let jobs: JobApplication[] = this.applicationService.HRapplications$$.value;
  let index = jobs.findIndex((res: JobApplication) => res.id === data.id)
  jobs.splice(index, 1)
  this.applicationService.HRapplications$$.next(jobs)
  this.applicationService.Rejectedapplications$$.next([data,  ...this.applicationService.Rejectedapplications$$.value])
})}

}
