import { DataSource, CollectionViewer } from "@angular/cdk/collections";
import { MatDialogRef } from "@angular/material/dialog";
import { SortDirection } from "@angular/material/sort";
import { BehaviorSubject, Observable, catchError, of, finalize, map, tap } from "rxjs";
import { SkillCategoryType } from "src/app/shared/enum/skill-category-type.enum";
import { Skill } from "src/app/shared/models/skill";
import { SkillWithCategory } from "src/app/shared/models/skill-with-category";
import { AddSkillFormComponent } from "src/app/skill/add-skill-form/add-skill-form.component";
import { SkillApiService } from "./skill-api.service";
import { SkillsService } from "./skill.service";

export class SkillsDataSource implements DataSource<SkillWithCategory> {
  
  length: number = 0;
  private SkillsSubject = new BehaviorSubject<SkillWithCategory[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);

  public loading$ = this.loadingSubject.asObservable();

  constructor(private skillService: SkillsService) {}

  connect(collectionViewer: CollectionViewer): Observable<SkillWithCategory[]> {
      return this.SkillsSubject.asObservable();
  }

  disconnect(collectionViewer: CollectionViewer): void {
      this.SkillsSubject.complete();
      this.loadingSubject.complete();
  }

  loadSkill(filterValue = '', direction = 'asc', pageIndex = 0, size = 5) {
                this.skillService.loadSkill().subscribe(
                  (res) => {
                    this.skillService.Skills$.pipe(
                      map((res: Skill[]) => {
                        let skillsWithcategories: SkillWithCategory[] = res.map((res: Skill) => {
                          console.log(SkillCategoryType[res.skillCategory])
                          let skillCategory: SkillWithCategory = {...res, skillCategory: SkillCategoryType[res.skillCategory] };
                          return skillCategory;
                        })
                        console.log(skillsWithcategories)
                        return skillsWithcategories;
                      }),
                      tap((res: SkillWithCategory[]) => {
                        this.length = res.length;
                        if (filterValue != '') {
                          res = res.filter(data => data.skillCategory.toLocaleLowerCase().includes(filterValue) || data.description.toLocaleLowerCase().includes(filterValue) || data.name.toLocaleLowerCase().includes(filterValue))
                        }
                        switch (direction) {
                          case 'asc': {
                           res = res.sort()
                          }
                          case 'desc': {
                            res = res.sort().reverse();
                           }
                        }
                        let start: number = (pageIndex) * size;
                        let end: number =start + size
                        this.SkillsSubject.next(res.slice(start,end))
                      }),
              catchError(() => of([])),
          )
          .subscribe()
                  }
                ) ;
  }    
  

  
}