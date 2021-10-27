import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/account/account.service';
import { SharedService } from 'src/app/shared/shared.service';
import { Pet } from '../pet';
import { planOptions } from '../planOptions';
import { quoteDisplay } from '../quoteDisplay';
import emailjs, { EmailJSResponseStatus } from 'emailjs-com';
import { Router } from '@angular/router';

@Component({
  selector: 'app-quote',
  templateUrl: './quote.component.html',
  styleUrls: ['./quote.component.css']
})
export class QuoteComponent implements OnInit {
  pets: Pet[] = [];
  plans: quoteDisplay[] = [];
  petPlans: planOptions[] = [];
  constructor(private acc: AccountService, private service: SharedService, private router: Router) { }

  ngOnInit(): void {
    this.acc.user$.subscribe(p => {
      if (p) {
        this.service.getPets(p).subscribe(x => {
          this.pets = x.filter(x => x.isInsured == false);
          if (this.pets.length > 1) {
            console.log("sending pets", this.pets)
            this.service.getQuote(this.pets).subscribe(res => {
              console.log("response of quotes", res);
              this.plans = res;




              this.pets.forEach(pet => {
                let foundPlan: quoteDisplay | undefined = this.plans.find(plan => plan.petId == pet.id)

                if (foundPlan) {

                  console.log(`found insurance option for ${pet.id}`)
                  let option: planOptions;
                  option = {
                    petId: pet.id,
                    silverCost: foundPlan.silverCost,
                    goldCost: foundPlan.goldCost,
                    breed: pet.breed,
                    age: pet.age,
                    location: pet.location,
                    insurancePlan: "",
                    insuranceMonthly: "",
                  }
                  this.petPlans.push(option)



                }
                else {
                  console.log(`no insurance for ${pet.id} in ${pet.location}`)
                }
              })
            })
          }




          // this.pets.forEach(pet => {

          //   if (this.plans.find(plan => plan.petId == pet.id)) {
          //     console.log(`found insurance option for ${pet.id}`)




          //   }
          //   else {
          //     console.log(`no insurance for ${pet.id}`)
          //   }
          // })




        })
      }
    }

    )
  }
  public sendEmail(e: Event) {
    e.preventDefault();
    emailjs.sendForm('service_v2bvq0h', 'template_ysypmop', e.target as HTMLFormElement, 'user_EQxzhd1kES8Lhjv21zZOC')
      .then((result: EmailJSResponseStatus) => {
        console.log(result.text);
        alert("Email Sent Successfully!")
        this.router.navigate(['purchase']);
      }, (error) => {
        console.log(error.text);
      });
  }
  onSubmit() {




  }
}