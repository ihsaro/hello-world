import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { Router } from '@angular/router';
import { fromEvent, debounceTime, distinctUntilChanged, tap, merge } from 'rxjs';
import { JobAdvertDataSource } from '../core/services/job-advert/job-advert-datasource';
import { JobAdvertService } from '../core/services/job-advert/job-advert.service';
import { SkillsDataSource } from '../core/services/skills/skill-datasource';
import { SkillsService } from '../core/services/skills/skill.service';
import { JobPostingWithEnum } from '../shared/models/JobPostingWithEnumName';
import { SkillWithCategory } from '../shared/models/skill-with-category';
import { AddSkillFormComponent } from '../skill/add-skill-form/add-skill-form.component';
import { AddJobFormComponent } from './components/add-job-form/add-job-form.component';

@Component({
  selector: 'app-job-advert',
  templateUrl: './job-advert.component.html',
  styleUrls: ['./job-advert.component.css']
})
export class JobAdvertComponent implements OnInit {

  datasource!: JobAdvertDataSource;
  displayedColumns: string[] = [ 'Title', 'Guild', 'Status', 'Actions'];
  totalData!: number;

  @ViewChild(MatTable) table! :MatTable<JobPostingWithEnum>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild('input') input!: ElementRef;

  constructor(public dialog: MatDialog, private  jobAdvertService: JobAdvertService, private router: Router) {
  }
  ngOnInit(): void {
    this.datasource = new JobAdvertDataSource(this.jobAdvertService);
    this.datasource.loadJobPosting('', 'asc', 0, 5)
  }

  ngAfterViewInit() {
    fromEvent(this.input.nativeElement,'keyup')
    .pipe(
        debounceTime(150),
        distinctUntilChanged(),
        tap(() => {
            this.paginator.pageIndex = 0;
            this.loadJobAdvertsPage();
        })
    )
    .subscribe();

// reset the paginator after sorting
this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

// on sort or paginate events, load a new page
merge(this.sort.sortChange, this.paginator.page)
.pipe(
    tap(() => this.loadJobAdvertsPage())
)
.subscribe();
  }

  loadJobAdvertsPage() {
    this.datasource.loadJobPosting(this.input.nativeElement.value,
      this.sort.direction,
      this.paginator.pageIndex,
      this.paginator.pageSize)
}



  openDialog(): void {
    this.dialog.open(AddJobFormComponent, {
      width: '650px',
      enterAnimationDuration: '400ms',
      exitAnimationDuration:'200ms',
      autoFocus: false
    });
  }

  goApplicants(id : number) {
    this.router.navigate([`dashboard/job/${id}/applicants`])
  }

}
