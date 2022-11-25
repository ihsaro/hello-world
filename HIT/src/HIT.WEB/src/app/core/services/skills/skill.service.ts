import { Injectable } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Observable, tap, BehaviorSubject, of } from 'rxjs';
import { SkillCategoryType } from 'src/app/shared/enum/skill-category-type.enum';
import { Skill } from 'src/app/shared/models/skill';
import { SkillWithCategory } from 'src/app/shared/models/skill-with-category';
import { AddSkillFormComponent } from 'src/app/skill/add-skill-form/add-skill-form.component';
import { ToasterService } from '../toaster.service';
import { SkillApiService } from './skill-api.service';

@Injectable({
  providedIn: 'root'
})
export class SkillsService {
  examples: Skill[] = [
    {
      name: ".Net6",
      description: "Programming Language",
      skillCategory: 0
    },
    {
      name: ".Communication Skills",
      description: "Team",
      skillCategory: 1
    },
    {
      name: "Angular",
      description: "Frontend Framework",
      skillCategory: 0
    },
    {
      name: "Azure",
      description: "Cloud",
      skillCategory: 0
    },
    {
      name: "Css",
      description: "styling",
      skillCategory: 0
    },
    {
      name: "Leadership",
      description: "team",
      skillCategory: 1
    },
    {
      name: "Power BI",
      description: "Programming Language",
      skillCategory: 2
    },
  ]
  constructor(private api: SkillApiService, private toastr: ToasterService){}
  
  private Skills$$ = new BehaviorSubject<Skill[]>([]);
  Skills$ = this.Skills$$.asObservable();

  addSkill(newSkill: Skill, dialog: MatDialogRef<AddSkillFormComponent>) {
    return this.api.create(newSkill).pipe(
      tap((res : Skill) => {
        let x: SkillWithCategory = {
          ...res, skillCategory: SkillCategoryType[res.skillCategory]
        } 
        this.Skills$$.next([res, ...this.Skills$$.getValue()])
        dialog.close();
        this.toastr.success("Skill added successfully!!!")
      })
    );
  }

  loadSkill(): Observable<Skill[]> {
    return this.api.GetAll().pipe(
    // return of(this.examples).pipe(
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
