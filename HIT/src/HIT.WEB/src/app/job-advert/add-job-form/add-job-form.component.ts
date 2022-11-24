import { ENTER, COMMA, S } from '@angular/cdk/keycodes';
import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';
import { MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { MatDialogRef } from '@angular/material/dialog';
import {  map, Observable, startWith } from 'rxjs';
import { SkillApiService } from 'src/app/core/services/skills/skill-api.service';
import { JobLocation, jobLocations } from 'src/app/shared/enum/JobLocation.enum';
import { JobStatus  } from 'src/app/shared/enum/JobStatus.enum.';
import { JobType, jobTypes } from 'src/app/shared/enum/JobType.enum';
import { CreateJobPosting } from 'src/app/shared/models/CreateJobPosting';
import { Skill } from 'src/app/shared/models/skill';

@Component({
  selector: 'app-add-job-form',
  templateUrl: './add-job-form.component.html',
  styleUrls: ['./add-job-form.component.css']
})
export class AddJobFormComponent implements OnInit {
  skillFilterControl = new FormControl('', [Validators.maxLength(100)]);
  skillsInControl: any[] = [];
  filteredSkills!: Observable<Skill[]>;
  skills!: Skill[];
  jobLocs = jobLocations;
  guilds = jobTypes;
  readonly separatorKeysCodes = [ENTER, COMMA] as const;

  jobForm = this.fb.group({
    title: ['', [Validators.required]],
    description: ['', [Validators.required]],
    yearsOfExperience: ['', [Validators.required]],
    jobLocation: ['', [Validators.required]],
    jobtype: ['', [Validators.required]],
    jobSkills: [[], [Validators.required]],
  })

  constructor(private fb:FormBuilder,private skillService: SkillApiService ,  private dialogRef: MatDialogRef<AddJobFormComponent>) { }

  formError(controlName: string, errorName: string) {
    return (this.jobForm.get(controlName)!.hasError(errorName) && this.jobForm.get(controlName)!.touched)
  }

  ngOnInit(): void {
    this.skillService.GetAll().subscribe({
      next: (res: Skill[]) => (this.skills = res),
      complete: () => {
        this.filteredSkills = this.onFilterSkillChange(
          this.skills,
          this.filteredSkills,
          this.skillFilterControl,
          this.skillsInControl
        );
      },
    });
  }
  

  addSkillToForm(skill: number) {
    this.skillsInControl.push(skill);
    this.jobForm.controls['jobSkills'].setValue(this.skillsInControl || null);
    this.jobForm.controls['jobSkills'].updateValueAndValidity();
    this.skillFilterControl.reset('');
    this.filteredSkills = this.onFilterSkillChange(
      this.skills,
      this.filteredSkills,
      this.skillFilterControl,
      this.skillsInControl
    );
  }

  onFilterSkillChange(
    skills: Skill[],
    filteredSkills: Observable<Skill[]>,
    skillFilterControl: FormControl,
    skillInControl: any
  ): Observable<Skill[]> {
    return (filteredSkills = skillFilterControl.valueChanges.pipe(
      startWith(''),
      map((value) => {
        if (typeof value != 'string') {
          return skills;
        }
        return this.filter(value || '',skills, skillInControl);
      })
    ))
  }

  filter(
    value: string,
    skills: Skill[],
    skillInControl: any
  ): Skill[] {
    const filterValue = value.toLowerCase();
    let controlNames: any[] = skillInControl.map(
      (skill: Skill) => skill.name
    );
    let filterskill = skills.filter(
      (skill) => !controlNames.includes(skill.name)
    );
    if (value.length >= 3) {
      return filterskill.filter((skill) =>
        skill.name.toLowerCase().includes(filterValue)
      );
    }
    return filterskill;
  }

  checkSkillExists(name: string) {
    return !this.filter(name, this.skills, this.skillsInControl)
      .map((skill: Skill) => skill.name)
      .includes(name);
  }

  selectedAddSkill(event: MatAutocompleteSelectedEvent): void {
    const skill = event.option.value;
    this.addSkillToForm(skill);
  }

  removeSkill(skill: any): void {
    this.removeSkillFromControl(skill);

    this.filteredSkills = this.onFilterSkillChange(
      this.skills,
      this.filteredSkills,
      this.skillFilterControl,
      this.skillsInControl
    );
  }

  removeSkillFromControl(
    skill: any
  ): void {
    const index = this.skillsInControl.indexOf(skill);
    this.skillsInControl.splice(index, 1);
  
    if (index >= 0) {
      this.jobForm.controls['jobSkills'].setValue(this.skillsInControl);
      this.jobForm.controls['jobSkills'].updateValueAndValidity();
    }
  }
  

  onSubmit() {
    if (this.jobForm.valid) {
      let allSkills = this.jobForm.value.jobSkills as unknown as Skill[];
      let newSkills: (number| undefined) [] = allSkills.map((skill) => skill.id )
      let newJob: CreateJobPosting = {
        skills: newSkills, jobStatus: JobStatus.OPEN, title: this.jobForm.value.title || "",
         description: this.jobForm.value.description || "",
         jobLocation: Number(this.jobForm.value.jobLocation) || JobLocation.MAURITIUS,
         jobtype: Number(this.jobForm.value.jobtype) || JobType.Development,
         yearsOfExperience: Number(this.jobForm.value),
      }
      console.log(newJob)
    }
   
  }
  
}
