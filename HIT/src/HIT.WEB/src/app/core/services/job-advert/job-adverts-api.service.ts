import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { JobPosting } from 'src/app/shared/models/JobPosting';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class JobAdvertApiService {

  api: string = `${environment.api}/job-Postings`;
  constructor(private httpClient: HttpClient, private router: Router) { }

  create(newJobPosting: JobPosting): Observable<JobPosting> {
   return this.httpClient.post<JobPosting>(this.api, newJobPosting)
  }

  GetAll(): Observable<JobPosting[]> {
    return this.httpClient.get<JobPosting[]>(this.api);
  }

  update(updatedJobPosting: JobPosting): Observable<JobPosting> {
    return this.httpClient.put<JobPosting>(this.api, updatedJobPosting);
  }

  delete(id: number): Observable<JobPosting> {
    return this.httpClient.delete<JobPosting>(`${this.api}/${id}`);
  }
}
