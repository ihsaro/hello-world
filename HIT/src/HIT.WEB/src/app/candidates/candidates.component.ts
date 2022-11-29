import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { fromEvent, debounceTime, distinctUntilChanged, tap, merge } from 'rxjs';
import { CandidatesService } from '../core/services/candidates/candidate.service';
import { CandidatesDataSource } from '../core/services/candidates/skill-datasource';
import { SkillsDataSource } from '../core/services/skills/skill-datasource';
import { SkillsService } from '../core/services/skills/skill.service';
import { CandidateWithType } from '../shared/models/candidateWithType';
import { SkillWithCategory } from '../shared/models/skill-with-category';
import { AddSkillFormComponent } from '../skill/add-skill-form/add-skill-form.component';

@Component({
  selector: 'app-candidates',
  templateUrl: './candidates.component.html',
  styleUrls: ['./candidates.component.css']
})
export class CandidatesComponent implements OnInit, AfterViewInit {


  datasource!: CandidatesDataSource;
  displayedColumns: string[] = [ 'Name', 'Email','location', 'type', 'actions'];
  totalData!: number;

  @ViewChild(MatTable) table! :MatTable<CandidateWithType>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild('input') input!: ElementRef;

  constructor(public dialog: MatDialog, private candidateService: CandidatesService) {
  }
  ngOnInit(): void {
    this.datasource = new CandidatesDataSource(this.candidateService);
    this.datasource.loadCandidate('', 'asc', 0, 5)
  }

  ngAfterViewInit() {
    fromEvent(this.input.nativeElement,'keyup')
    .pipe(
        debounceTime(150),
        distinctUntilChanged(),
        tap(() => {
            this.paginator.pageIndex = 0;
            this.loadSkillsPage();
        })
    )
    .subscribe();

// reset the paginator after sorting
this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

// on sort or paginate events, load a new page
merge(this.sort.sortChange, this.paginator.page)
.pipe(
    tap(() => this.loadSkillsPage())
)
.subscribe();
  }

  loadSkillsPage() {
    this.datasource.loadCandidate(this.input.nativeElement.value,
      this.sort.direction,
      this.paginator.pageIndex,
      this.paginator.pageSize)
}

  openDialog(): void {
    this.dialog.open(AddSkillFormComponent, {
      width: '450px',
      enterAnimationDuration: '400ms',
      exitAnimationDuration:'200ms',
      autoFocus: false
    });
  }

}
