import { DataSource, CollectionViewer } from "@angular/cdk/collections";
import { BehaviorSubject, Observable, catchError, of, map, tap } from "rxjs";
import { CandidateType } from "src/app/shared/enum/CandidateType";
import { Candidate } from "src/app/shared/models/candidate";
import { CandidateWithType } from "src/app/shared/models/candidateWithType";
import { CandidatesService } from "./candidate.service";

export class CandidatesDataSource implements DataSource<CandidateWithType> {
  
  length: number = 0;
  private CandidatesSubject = new BehaviorSubject<CandidateWithType[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);

  public loading$ = this.loadingSubject.asObservable();

  constructor(private CandidateService: CandidatesService) {}

  connect(collectionViewer: CollectionViewer): Observable<CandidateWithType[]> {
      return this.CandidatesSubject.asObservable();
  }

  disconnect(collectionViewer: CollectionViewer): void {
      this.CandidatesSubject.complete();
      this.loadingSubject.complete();
  }

  loadCandidate(filterValue = '', direction = 'asc', pageIndex = 0, size = 5) {
                this.CandidateService.loadCandidate().subscribe(
                  (res) => {
                    this.CandidateService.Candidates$.pipe(
                      map((res: Candidate[]) => {
                        let CandidatesWithcategories: CandidateWithType[] = res.map((res: Candidate) => {
                          let CandidateCategory: CandidateWithType = {...res, candidateType: CandidateType[res.candidateType], YearsOfExperience: res.yearsOfExperience };
                          return CandidateCategory;
                        })
                        return CandidatesWithcategories;
                      }),
                      tap((res: CandidateWithType[]) => {
                        this.length = res.length;
                        if (filterValue != '') {
                          res = res.filter(data => data.firstName.toLocaleLowerCase().includes(filterValue) || data.lastName.toLocaleLowerCase().includes(filterValue) || data.emailAddress.toLocaleLowerCase().includes(filterValue)|| data.candidateType.toLocaleLowerCase().includes(filterValue))
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
                        this.CandidatesSubject.next(res.slice(start,end))
                      }),
              catchError(() => of([])),
          )
          .subscribe()
                  }
                ) ;
  }    
  

  
}