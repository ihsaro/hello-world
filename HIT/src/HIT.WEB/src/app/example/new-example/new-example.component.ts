import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-new-example',
  templateUrl: './new-example.component.html',
  styleUrls: ['./new-example.component.css']
})
export class NewExampleComponent implements OnInit {

  exampleForm = this.fb.group({
    name: ['', [Validators.required]],
    age: ['', [Validators.required]],
    address: ['', [Validators.required]],
  })

  constructor(private fb:FormBuilder, private dialogRef: MatDialogRef<NewExampleComponent>) { }

  formError(controlName: string, errorName: string) {
    return (this.exampleForm.get(controlName)!.hasError(errorName) && this.exampleForm.get(controlName)!.touched)
  }

  ngOnInit(): void {
  }

}
