import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  public registerForm: FormGroup = new FormGroup({
    firstname: new FormControl(''),
    lastname: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl('')
  });

  constructor() { }

  //getters
  get firstname(): AbstractControl | null {
    return this.registerForm.get('firstname');
  }
  get lastnamename(): AbstractControl | null {
    return this.registerForm.get('lastname');
  }
  get email(): AbstractControl | null {
    return this.registerForm.get('email');
  }
  get password(): AbstractControl | null {
    return this.registerForm.get('password');
  }


  ngOnInit(): void {
  }
  
  public createUser(): void {
    console.log(this.registerForm.value.email);
    localStorage.setItem(this.registerForm.value.email, this.registerForm.value.password);
    console.log(localStorage);
  }

}
