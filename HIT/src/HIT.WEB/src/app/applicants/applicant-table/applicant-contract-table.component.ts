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
import { ContractApplicantDataSource } from 'src/app/core/services/applicants/contract-datasource';
import { JobAdvertApiService } from 'src/app/core/services/job-advert/job-adverts-api.service';
import { ContractComponent } from '../contract/contract.component';
import { ApplicantsViewComponent } from '../applicants-view/applicants-view.component';

@Component({
  selector: 'app-contract-applicant-table',
  templateUrl: './applicant-table.component.html',
  styleUrls: ['./applicant-table.component.css']
})
export class ContractApplicantTableComponent implements OnInit, AfterViewInit {
  datasource!: ContractApplicantDataSource;
  displayedColumns: string[] =['Name', 'Email', 'Location', 'rate', 'Actions'];
  totalData!: number;
  @Input() userId = 1;

  @ViewChild(MatTable) table! :MatTable<JobApplication>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild('input') input!: ElementRef;

  constructor(public dialog: MatDialog, private  applicationService: ApplicantsService, private router: Router, private jobAppService: JobAdvertApiService) {
  }

  ngOnInit(): void {
    this.datasource = new ContractApplicantDataSource(this.applicationService);
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


back(data: JobApplication) {
  this.jobAppService.UpdatePhase(data.id!, 2).subscribe((res) => {
    let jobs: JobApplication[] = this.applicationService.Contractapplications$$.value;
    let index = jobs.findIndex((res: JobApplication) => res.id === data.id)
    jobs.splice(index, 1)
    this.applicationService.Contractapplications$$.next(jobs)
    this.applicationService.HRapplications$$.next([data,  ...this.applicationService.HRapplications$$.value])
  })
}

openDialog(): void {
  this.dialog.open(ContractComponent, {
    width: '450px',
    enterAnimationDuration: '400ms',
    exitAnimationDuration:'200ms',
    autoFocus: false
  });
}


reject(data: JobApplication) {
  this.jobAppService.UpdatePhase(data.id!, -1).subscribe((res) => {
  let jobs: JobApplication[] = this.applicationService.Contractapplications$$.value;
  let index = jobs.findIndex((res: JobApplication) => res.id === data.id)
  jobs.splice(index, 1)
  this.applicationService.Contractapplications$$.next(jobs)
  this.applicationService.Rejectedapplications$$.next([{...data, applicationPhase: ApplicationPhase.REJECTED} ,  ...this.applicationService.Rejectedapplications$$.value])
})}

openView(data: JobApplication) {
  this.dialog.open(ApplicantsViewComponent, {
    width: '750px',
    enterAnimationDuration: '400ms',
    exitAnimationDuration:'200ms',
    autoFocus: false,
    data: {data}
  });
}


}
