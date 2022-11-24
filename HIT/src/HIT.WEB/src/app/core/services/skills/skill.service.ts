import { Injectable } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Observable, tap, BehaviorSubject, of } from 'rxjs';
import { Skill } from 'src/app/shared/models/skill';
import { AddSkillFormComponent } from 'src/app/skill/add-skill-form/add-skill-form.component';
import { SkillApiService } from './skill-api.service';

@Injectable({
  providedIn: 'root'
})
export class SkillsService {
  examples: Skill[] = [
    {
      name: ".Net6",
      description: "Programming Language",
      category: 0
    },
    {
      name: ".Communication Skills",
      description: "Team",
      category: 1
    },
    {
      name: "Angular",
      description: "Frontend Framework",
      category: 0
    },
    {
      name: "Azure",
      description: "Cloud",
      category: 0
    },
    {
      name: "Css",
      description: "styling",
      category: 0
    },
    {
      name: "Leadership",
      description: "team",
      category: 1
    },
    {
      name: "Power BI",
      description: "Programming Language",
      category: 2
    },
  ]
  constructor(private api: SkillApiService){}
  
  private Skills$$ = new BehaviorSubject<Skill[]>([]);
  Skills$ = this.Skills$$.asObservable();

  addSkill(newSkill: Skill, dialog: MatDialogRef<AddSkillFormComponent>) {
    return this.api.create(newSkill).pipe(
      tap((res : Skill) => {
        this.Skills$$.next([res, ...this.Skills$$.getValue()])
        dialog.close();
      })
    );
  }

  loadSkill(): Observable<Skill[]> {
  //   return this.api.GetAll().pipe(
    return of(this.examples).pipe(
      tap((res: Skill[]) => {
        this.Skills$$.next(res)
      })
    )
  }

  // editSkill(updatedSkill: Skill): Observable<Skill> {
  //   return this.api.update(updatedSkill).pipe(
  //     tap(() => {
  //       const allSkills = this.Skills$$.getValue();
  //       const index = allSkills.findIndex((Skill) => Skill.id == updatedSkill.id);
  //       allSkills[index] = updatedSkill;
  //       this.Skills$$.next([...allSkills]);
  //       this.toaster.success("Skill successfully updated");
  //     })
  //   )
  // }

  // deleteSkill(id: number): Observable<Skill> {
  //   return this.api.delete(id).pipe(
  //     tap(() => {
  //       const allSkills = this.Skills$$.getValue();
  //       const index = allSkills.findIndex((Skill) => Skill.id == id);
  //       allSkills.splice(index, 1)
  //       this.Skills$$.next([...allSkills]);
  //       this.toaster.success("Skill successfully deleted");
  //     })
  //   )
  // }

}
