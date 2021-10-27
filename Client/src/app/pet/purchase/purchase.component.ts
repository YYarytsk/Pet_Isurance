import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/account/account.service';
import { SharedService } from 'src/app/shared/shared.service';
import { Pet } from '../pet';
import { PetService } from '../pet.service';

@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})
export class PurchaseComponent implements OnInit {
  

  constructor(private acc: AccountService, private service: SharedService, private formBuilder: FormBuilder, private router: Router) { }
  pets: Pet[] = [];


  form: FormGroup = new FormGroup(
    {
      username: new FormControl(''),
      cardNumber: new FormControl(''),
      expiry_month: new FormControl(''),
      expiry_year: new FormControl(''),
      password: new FormControl('')
    });
    
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      username: ['', Validators.required],
      cardNumber: ['', Validators.required],
      expiry_month: ['', Validators.required],
      expiry_year: ['', Validators.required],
      password: ['', Validators.required]
    })
    this.acc.user$.subscribe(p => {
      console.log(p);
      if (p) {
        this.service.getPets(p).subscribe(x => {
          this.pets = x;
          console.log("heyo", this.pets)
        })
      }
    });
  }




  onSubmit() {
    console.log("sup submit", this.pets);
    this.service.payForInsurance(this.pets);
    this.router.navigate(['purchase-status']);

  }

}
