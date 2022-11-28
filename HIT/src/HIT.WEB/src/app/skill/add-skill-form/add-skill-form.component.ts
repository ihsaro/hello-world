import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { SkillsService } from 'src/app/core/services/skills/skill.service';
import { SkillCategoryType } from 'src/app/shared/enum/skill-category-type.enum';
import { Skill } from 'src/app/shared/models/skill';

@Component({
  selector: 'app-new-example',
  templateUrl: './add-skill-form.component.html',
  styleUrls: ['./add-skill-form.component.css']
})
export class AddSkillFormComponent implements OnInit {

  categories = [
    {
      name: "Technical",
      value: SkillCategoryType.TECHNICAL
    },
    {
      name: "Soft",
      value: SkillCategoryType.SOFT
    },
    {
      name: "Management",
      value: SkillCategoryType.MANAGEMENT
    },
  ] 

  skillForm = this.fb.group({
    name: ['', [Validators.required]],
    description: ['', [Validators.required]],
    category: ['', [Validators.required]],
  })

  constructor( private fb:FormBuilder, private dialogRef: MatDialogRef<AddSkillFormComponent>, private skillService: SkillsService) { }

  formError(controlName: string, errorName: string) {
    return (this.skillForm.get(controlName)!.hasError(errorName) && this.skillForm.get(controlName)!.touched)
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if (this.skillForm.valid) {
      let x: Skill = {
        name: this.skillForm.value.name || "",
        skillCategory: Number(this.skillForm.value.category),
        description: this.skillForm.value.description || ""
        
      }
      this.skillService.addSkill(x, this.dialogRef).subscribe();
    } 
    this.skillForm.markAllAsTouched();
  }

}
