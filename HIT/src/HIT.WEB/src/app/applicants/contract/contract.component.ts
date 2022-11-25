import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { SkillsService } from 'src/app/core/services/skills/skill.service';
import { SkillCategoryType } from 'src/app/shared/enum/skill-category-type.enum';
import { Skill } from 'src/app/shared/models/skill';

@Component({
  selector: 'app-contract',
  templateUrl: './contract.component.html',
  styleUrls: ['./contract.component.css']
})
export class ContractComponent implements OnInit {
  contractForm = this.fb.group({
    title: ['', [Validators.required]],
    kind: ['', [Validators.required]],
    type: ['', [Validators.required]],
    country: ['', Validators.required]
  })

  constructor( private fb:FormBuilder, private dialogRef: MatDialogRef<ContractComponent>) { }

  formError(controlName: string, errorName: string) {
    return (this.contractForm.get(controlName)!.hasError(errorName) && this.contractForm.get(controlName)!.touched)
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if (this.contractForm.valid) {
        window.open("https://forms.office.com/r/Ar0ehDxmKc")
    }  else {
      this.contractForm.markAllAsTouched();
    }

  }

}
