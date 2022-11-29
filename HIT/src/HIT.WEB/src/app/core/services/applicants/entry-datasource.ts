import { DataSource, CollectionViewer } from "@angular/cdk/collections";
import { MatDialogRef } from "@angular/material/dialog";
import { SortDirection } from "@angular/material/sort";
import { BehaviorSubject, Observable, catchError, of, finalize, map, tap } from "rxjs";
import { ApplicantsService } from "./applicants.service";
import { JobApplication } from "src/app/shared/models/jobApplication";
import { CandidateType } from "src/app/shared/enum/CandidateType";
import { ApplicationPhase } from "src/app/shared/enum/ApplicationPhase";
import { filter } from "rxjs-compat/operator/filter";

export class EntryApplicantDataSource implements DataSource<JobApplication> {
  
  length: number = 0;
  private EntryApplicationsSubject = new BehaviorSubject<JobApplication[]>([]);
  

  constructor(private applicantService: ApplicantsService) {}

  connect(collectionViewer: CollectionViewer): Observable<JobApplication[]> {
      return this.EntryApplicationsSubject.asObservable();
  }

  disconnect(collectionViewer: CollectionViewer): void {
      this.EntryApplicationsSubject.complete();
  }

  loadJobApplication(id: number, filterValue = '', direction = 'asc', pageIndex = 0, size = 5) {
                this.applicantService.loadENTRYApplication(id, 0).subscribe(
                  (res) => {
                    this.applicantService.Entryapplications$.pipe(
                      tap((res: JobApplication[]) => {
                        this.length = res.length;
                        if (filterValue != '') {
                          res = res.filter(data => 
                            data.candidate.firstName.toLocaleLowerCase().includes(filterValue) || 
                            data.candidate.lastName.toLocaleLowerCase().includes(filterValue) || 
                            data.candidate.emailAddress.toLocaleLowerCase().includes(filterValue) || 
                            CandidateType[data.candidate.candidateType].toLocaleLowerCase().includes(filterValue) || 
                            data.candidate.candidateLocation.toLocaleLowerCase().includes(filterValue))
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
                        this.EntryApplicationsSubject.next(res.slice(start,end))
                      }),
              catchError(() => of([])),
          )
          .subscribe()
                  }
                ) ;
  }    
  

  
}