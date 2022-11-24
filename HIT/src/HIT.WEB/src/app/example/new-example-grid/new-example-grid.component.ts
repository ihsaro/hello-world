import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-new-example',
  templateUrl: './new-example-grid.component.html',
  styleUrls: ['./new-example-grid.component.css']
})
export class NewExampleGridComponent implements OnInit {

  exampleForm = this.fb.group({
    name: ['', [Validators.required]],
    age: ['', [Validators.required]],
    address: ['', [Validators.required]],
  })

  constructor(private fb:FormBuilder, private dialogRef: MatDialogRef<NewExampleGridComponent>) { }

  formError(controlName: string, errorName: string) {
    return (this.exampleForm.get(controlName)!.hasError(errorName) && this.exampleForm.get(controlName)!.touched)
  }

  ngOnInit(): void {
  }

}
