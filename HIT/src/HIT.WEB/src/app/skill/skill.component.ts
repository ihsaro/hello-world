import { AfterViewInit, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { debounceTime, distinctUntilChanged, fromEvent, merge, tap } from 'rxjs';
import { SkillApiService } from '../core/services/skills/skill-api.service';
import { SkillsDataSource } from '../core/services/skills/skill-datasource';
import { SkillsService } from '../core/services/skills/skill.service';
import { SkillWithCategory } from '../shared/models/skill-with-category';
import { AddSkillFormComponent } from './add-skill-form/add-skill-form.component';

@Component({
  selector: 'app-skill',
  templateUrl: './skill.component.html',
  styleUrls: ['./skill.component.css']
})
export class SkillComponent implements OnInit, AfterViewInit {


  datasource!: SkillsDataSource;
  displayedColumns: string[] = [ 'Name', 'Category','actions'];
  totalData!: number;

  @ViewChild(MatTable) table! :MatTable<SkillWithCategory>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild('input') input!: ElementRef;

  constructor(public dialog: MatDialog, private skillService: SkillsService) {
  }
  ngOnInit(): void {
    this.datasource = new SkillsDataSource(this.skillService);
    this.datasource.loadSkill('', 'asc', 0, 5)
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
    this.datasource.loadSkill(this.input.nativeElement.value,
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

  // applyFilter(event: Event) {
  //   const filterValue = (event.target as HTMLInputElement).value.toLocaleLowerCase();
  //   let data = this.skillService.skills.filter((data) => )
  //   // this.skillService.
  //   // this.dataSource.filter = filterValue.trim().toLowerCase();
  //   this.skillService.Skills$$.next(data);
  //   // if (this.dataSource.paginator) {
  //   //   this.dataSource.paginator.firstPage();
  //   // }
  // }
 }


