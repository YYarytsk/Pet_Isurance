import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { AccountService } from 'src/app/account/account.service';
import { User } from 'src/app/account/user';
import { SharedService } from 'src/app/shared/shared.service';
import { Pet } from '../pet';
import { PetService } from '../pet.service';


@Component({
  selector: 'app-questionnaire',
  templateUrl: './questionnaire.component.html',
  styleUrls: ['./questionnaire.component.css']
})
export class QuestionnaireComponent implements OnInit {
  constructor(private acc: AccountService, private formBuilder: FormBuilder, private service: SharedService) { }
  private userId: number = 0;
  pets: Pet[] = [];
  form: FormGroup = new FormGroup(
    {
      breed: new FormControl(''),
      age: new FormControl(''),
      location: new FormControl(''),
      userId: new FormControl('')
    });


  ngOnInit(): void {
    this.acc.user$.subscribe(p => {
      console.log(p);
      if (p) {
        this.service.getPets(p).subscribe(x => {
          console.log("wooo", x);
          this.pets = x;
          console.log("inside init", this.pets)
        })
      }
      else {
        const serializedPets: string | null = localStorage.getItem('pets');
        if (serializedPets)
          this.pets = JSON.parse(serializedPets);
      }
    });


    this.form = this.formBuilder.group({
      breed: [''],
      age: [''],
      location: [''],
      userId: ['']
    })
  }

  onSubmit() {

    let pet: Partial<Pet>;

    pet = {
      breed: this.form.value.breed,
      age: this.form.value.age,
      location: this.form.value.location,
      insurancePlan: "",
      insuranceMonthly: "",
    };
    console.log(pet.age);
    if (pet.age == null) {
      pet.age = 12.5;
    }
    this.pets.push(pet as Pet);

    this.acc.user$.subscribe(user => {
      if (user) {
        pet.userId = user.id;
        this.userId = user.id;
        this.service.addPet(pet as Pet).subscribe(res => {
          console.log("added pet", res);
          
        })
      }
      else {
        console.log("no user", this.pets);
        localStorage.setItem('pets', JSON.stringify(this.pets));
      }
      this.service.addPet(pet as Pet).subscribe(res => {
      })
    })



  }





}

