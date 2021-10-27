import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from '../account.service';
import { User } from '../user';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public registerForm !: FormGroup;

  constructor(private formBuilder: FormBuilder, private service: AccountService) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      userName: ['', Validators.required],
      password: ['', Validators.required],
      doB: ['', Validators.required],
      location: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      email: ['', Validators.required]
    })

  }

  onSubmit() {
    console.log(this.registerForm);
    this.service.register(this.registerForm.value).subscribe(user => {
      console.log(user);
    });
  }
}
