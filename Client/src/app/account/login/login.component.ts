import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AccountService } from '../account.service';
import { LoginRequest } from '../loginRequest';
import { User } from '../user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private service: AccountService, private formBuilder: FormBuilder) { }


  form: FormGroup = new FormGroup(
    {
      userName: new FormControl(''),
      password: new FormControl(''),
      email: new FormControl('')
    });




  ngOnInit(): void {
    this.form = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
      email: ['', Validators.required]
    })
  }



  onSubmit() {
    let request: LoginRequest;
    request = {
      userName: this.form.value.userName,
      email: this.form.value.email,
      password: this.form.value.password
    }
    this.service.logIn(request);
  }
}
