import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ApplicationPhase } from 'src/app/shared/enum/ApplicationPhase';
import { CreateJobPosting } from 'src/app/shared/models/CreateJobPosting';
import { JobApplication } from 'src/app/shared/models/jobApplication';
import { JobPosting } from 'src/app/shared/models/JobPosting';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class JobAdvertApiService {

  api: string = `${environment.api}/job-postings`;
  constructor(private httpClient: HttpClient, private router: Router) { }

  create(newJobPosting: CreateJobPosting) {
   return this.httpClient.post(this.api, newJobPosting)
  }

  GetAll(): Observable<JobPosting[]> {
    return this.httpClient.get<JobPosting[]>(this.api);
  }

  GetAllCandidates(id: number, phase: number): Observable<JobApplication[]> {
    return this.httpClient.get<JobApplication[]>( `${this.api}/${id}/candidates?phase=${phase}`);
  }

  UpdatePhase(id: number, phase: number): Observable<JobApplication[]> {
    console.log(phase)
    return this.httpClient.get<JobApplication[]>( `https://localhost:7152/api/v1/job-posting-applications/${id}/${phase}`);
  }

  update(updatedJobPosting: JobPosting): Observable<JobPosting> {
    return this.httpClient.put<JobPosting>(this.api, updatedJobPosting);
  }

  delete(id: number): Observable<JobPosting> {
    return this.httpClient.delete<JobPosting>(`${this.api}/${id}`);
  }
}
