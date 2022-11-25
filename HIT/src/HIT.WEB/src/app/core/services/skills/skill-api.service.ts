import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { Skill } from 'src/app/shared/models/skill';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SkillApiService {

  api: string = `${environment.api}/job-skills`;
  constructor(private httpClient: HttpClient, private router: Router) { }

  create(newSkill: Skill): Observable<Skill> {
   return this.httpClient.post<Skill>(this.api, newSkill)
  }

  GetAll(): Observable<Skill[]> {
    return this.httpClient.get<Skill[]>(this.api);
  }

  update(updatedSkill: Skill): Observable<Skill> {
    return this.httpClient.put<Skill>(this.api, updatedSkill);
  }

  delete(id: number): Observable<Skill> {
    return this.httpClient.delete<Skill>(`${this.api}/${id}`);
  }
}
