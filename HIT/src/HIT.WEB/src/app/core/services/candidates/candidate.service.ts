import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, tap, BehaviorSubject } from 'rxjs';
import { Candidate } from 'src/app/shared/models/Candidate';
import { environment } from 'src/environments/environment';
import { ToasterService } from '../toaster.service';

@Injectable({
  providedIn: 'root'
})
export class CandidatesService {
  constructor(private httpClient: HttpClient, private router: Router,private toastr: ToasterService){}
  
  private Candidates$$ = new BehaviorSubject<Candidate[]>([]);
  Candidates$ = this.Candidates$$.asObservable();

  api: string = `${environment.api}/candidates`;

  
  GetAll(): Observable<Candidate[]> {
    return this.httpClient.get<Candidate[]>(this.api);
  }

  loadCandidate(): Observable<Candidate[]> {
    return this.GetAll().pipe(
    // return of(this.examples).pipe(
      tap((res: Candidate[]) => {
        this.Candidates$$.next(res)
      })
    )
  }

}
