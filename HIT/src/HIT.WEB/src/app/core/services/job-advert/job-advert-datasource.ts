import { DataSource, CollectionViewer } from "@angular/cdk/collections";
import { BehaviorSubject, Observable, catchError, of, finalize, map, tap } from "rxjs";
import { SkillCategoryType } from "src/app/shared/enum/skill-category-type.enum";
import { JobPostingWithEnum } from "src/app/shared/models/JobPostingWithEnumName";
import { JobAdvertService } from "./job-advert.service";

export class JobAdvertDataSource implements DataSource<JobPostingWithEnum> {
  
  length: number = 0;
  private jobPosting$$ = new BehaviorSubject<JobPostingWithEnum[]>([]);

  constructor(private JobAdvert: JobAdvertService
  ) {}

  connect(collectionViewer: CollectionViewer): Observable<JobPostingWithEnum[]> {
      return this.jobPosting$$.asObservable();
  }

  disconnect(collectionViewer: CollectionViewer): void {
      this.jobPosting$$.complete();
  }

  loadJobPosting(filterValue = '', direction = 'asc', pageIndex = 0, size = 5) {
                this.JobAdvert.loadJobPosting().subscribe(
                  (res) => {
                    this.JobAdvert.jobPostings$.pipe(
                      tap((res: JobPostingWithEnum[]) => {
                        this.length = res.length;
                        if (filterValue != '') {
                          res = res.filter(data => data.jobLocation.toLocaleLowerCase().includes(filterValue) || data.description.toLocaleLowerCase().includes(filterValue) || data.title.toLocaleLowerCase().includes(filterValue)  || data.jobSkills.every((skill) => skill.name.toLocaleLowerCase().includes(filterValue) || SkillCategoryType[skill.category].toLocaleLowerCase().includes(filterValue)))
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
                        this.jobPosting$$.next(res.slice(start,end))
                      }),
              catchError(() => of([])),
          )
          .subscribe()
                  }
                ) ;
  }    
  

  
}