import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/data.service';
import { UsersService } from 'src/app/services/users.service';
import { RegisterComponent } from '../../shared/register/register.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public users=[];

  public loginForm: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(
    private router: Router,
    private dataService : DataService,
    private usersService: UsersService,
    public dialog: MatDialog,
  ) { }

    //getters
  get username(): AbstractControl | null {
    return this.loginForm.get('username');
  } 

  get password(): AbstractControl | null {
    return this.loginForm.get('password');
  }

  ngOnInit(): void {
    this.usersService.getAllUsers().subscribe(
      (result) => {
        console.log(result);
        this.users = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  public login() : void {
    const x = localStorage.getItem(this.loginForm.value.username);
    if (x!=null) {
      if (x == this.loginForm.value.password) {
        this.dataService.changeUserData(this.loginForm.value);
        localStorage.setItem('Role','Admin');
        this.router.navigate(['/artists']);
      }
      else {
        alert("Wrong password!");
      }
    }
    else
    {
      alert("Invalid username! Please register or try again!");
    }
  }

  public openModal(): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '400px';
    dialogConfig.height = '600px';
    this.dialog.open(RegisterComponent, dialogConfig);
  }

  public register() : void {
    this.openModal();

  }

}
