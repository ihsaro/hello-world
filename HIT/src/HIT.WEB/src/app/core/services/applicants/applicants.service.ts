import { Injectable } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Observable, tap, BehaviorSubject, of } from 'rxjs';
import { ApplicationPhase } from 'src/app/shared/enum/ApplicationPhase';
import { SkillCategoryType } from 'src/app/shared/enum/skill-category-type.enum';
import { JobApplication } from 'src/app/shared/models/jobApplication';
import { Skill } from 'src/app/shared/models/skill';
import { SkillWithCategory } from 'src/app/shared/models/skill-with-category';
import { AddSkillFormComponent } from 'src/app/skill/add-skill-form/add-skill-form.component';
import { JobAdvertApiService } from '../job-advert/job-adverts-api.service';
import { SkillApiService } from '../skills/skill-api.service';
import { ToasterService } from '../toaster.service';

@Injectable({
  providedIn: 'root'
})
export class ApplicantsService {
  constructor(private api: JobAdvertApiService, private toastr: ToasterService){}
  
  public Entryapplications$$  = new BehaviorSubject<JobApplication[]>([]);
  public Entryapplications$ = this.Entryapplications$$.asObservable();
  public HRapplications$$ = new BehaviorSubject<JobApplication[]>([]);
  public HRapplications$ = this.HRapplications$$.asObservable();
  public TECHapplications$$ = new BehaviorSubject<JobApplication[]>([]);
  public TECHapplications$ = this.TECHapplications$$.asObservable();
  public Contractapplications$$ = new BehaviorSubject<JobApplication[]>([]);
  public Contractapplications$ = this.Contractapplications$$.asObservable();
  public Rejectedapplications$$ = new BehaviorSubject<JobApplication[]>([]);
  public Rejectedapplications$ = this.Rejectedapplications$$.asObservable();

  // addSkill(newSkill: Skill, dialog: MatDialogRef<AddSkillFormComponent>) {
  //   return this.api.create(newSkill).pipe(
  //     tap((res : Skill) => {
  //       let x: SkillWithCategory = {
  //         ...res, skillCategory: SkillCategoryType[res.skillCategory]
  //       } 
  //       this.applications$$.next([res, ...this.applications$$.getValue()])
  //       dialog.close();
  //       this.toastr.success("Skill added successfully!!!")
  //     })
  //   );
  // }

  loadHRApplication(id: number, phase:number): Observable<JobApplication[]> {
    return this.api.GetAllCandidates(id, phase).pipe(
    // return of(this.examples).pipe(
      tap((res: JobApplication[]) => {
        
        this.HRapplications$$.next(res)
      })
    )
  }

  loadENTRYApplication(id: number, phase:number): Observable<JobApplication[]> {
    return this.api.GetAllCandidates(id, phase).pipe(
    // return of(this.examples).pipe(
      tap((res: JobApplication[]) => {
        
        this.Entryapplications$$.next(res)
      })
    )
  }

  loadTECHApplication(id: number, phase:number): Observable<JobApplication[]> {
    return this.api.GetAllCandidates(id, phase).pipe(
    // return of(this.examples).pipe(
      tap((res: JobApplication[]) => {
        
        this.TECHapplications$$.next(res)
      })
    )
  }

  loadCONTRACTApplication(id: number, phase:number): Observable<JobApplication[]> {
    return this.api.GetAllCandidates(id, phase).pipe(
    // return of(this.examples).pipe(
      tap((res: JobApplication[]) => {
        
        this.Contractapplications$$.next(res)
      })
    )
  }

  loadREJECTEDApplication(id: number, phase:number): Observable<JobApplication[]> {
    return this.api.GetAllCandidates(id, phase).pipe(
    // return of(this.examples).pipe(
      tap((res: JobApplication[]) => {
        
        this.Rejectedapplications$$.next(res)
      })
    )
  }

  // editSkill(updatedSkill: Skill): Observable<Skill> {
  //   return this.api.update(updatedSkill).pipe(
  //     tap(() => {
  //       const allSkills = this.applications$$.getValue();
  //       const index = allSkills.findIndex((Skill) => Skill.id == updatedSkill.id);
  //       allSkills[index] = updatedSkill;
  //       this.applications$$.next([...allSkills]);
  //       this.toaster.success("Skill successfully updated");
  //     })
  //   )
  // }

  // deleteSkill(id: number): Observable<Skill> {
  //   return this.api.delete(id).pipe(
  //     tap(() => {
  //       const allSkills = this.applications$$.getValue();
  //       const index = allSkills.findIndex((Skill) => Skill.id == id);
  //       allSkills.splice(index, 1)
  //       this.applications$$.next([...allSkills]);
  //       this.toaster.success("Skill successfully deleted");
  //     })
  //   )
  // }

}
