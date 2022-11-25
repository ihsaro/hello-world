import { DataSource, CollectionViewer } from "@angular/cdk/collections";
import { MatDialogRef } from "@angular/material/dialog";
import { SortDirection } from "@angular/material/sort";
import { BehaviorSubject, Observable, catchError, of, finalize, map, tap } from "rxjs";
import { ApplicantsService } from "./applicants.service";
import { JobApplication } from "src/app/shared/models/jobApplication";
import { CandidateType } from "src/app/shared/enum/CandidateType";
import { ApplicationPhase } from "src/app/shared/enum/ApplicationPhase";
import { filter } from "rxjs-compat/operator/filter";

export class ContractApplicantDataSource implements DataSource<JobApplication> {
  
  length: number = 0;
  private ContractApplicationsSubject = new BehaviorSubject<JobApplication[]>([]);
  

  constructor(private applicantService: ApplicantsService) {}

  connect(collectionViewer: CollectionViewer): Observable<JobApplication[]> {
      return this.ContractApplicationsSubject.asObservable();
  }

  disconnect(collectionViewer: CollectionViewer): void {
      this.ContractApplicationsSubject.complete();
  }

  loadJobApplication(id: number, filterValue = '', direction = 'asc', pageIndex = 0, size = 5) {
                this.applicantService.loadCONTRACTApplication(id, 3).subscribe(
                  (res) => {
                    this.applicantService.Contractapplications$.pipe(
                      tap((res: JobApplication[]) => {
                        this.length = res.length;
                        if (filterValue != '') {
                          res = res.filter(data => 
                            data.Candidate.firstName.toLocaleLowerCase().includes(filterValue) || 
                            data.Candidate.lastName.toLocaleLowerCase().includes(filterValue) || 
                            data.Candidate.emailAddress.toLocaleLowerCase().includes(filterValue) || 
                            CandidateType[data.Candidate.candidateType].toLocaleLowerCase().includes(filterValue) || 
                            data.Candidate.candidateLocation.toLocaleLowerCase().includes(filterValue))
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
                        this.ContractApplicationsSubject.next(res.slice(start,end))
                      }),
              catchError(() => of([])),
          )
          .subscribe()
                  }
                ) ;
  }    
  

  
}