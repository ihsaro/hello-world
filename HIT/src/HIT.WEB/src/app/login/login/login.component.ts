import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{

  loginForm = this.fb.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required]
  })

  constructor( private fb: FormBuilder, private router: Router) { }

  onSubmit() {
    this.router.navigate(['../dashboard'])
  }

  formError(controlName: string, errorName: string) {
    return (
      this.loginForm.get(controlName)!.hasError(errorName) &&
      this.loginForm.get(controlName)!.touched
    );
  }
}
