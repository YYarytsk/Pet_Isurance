import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import emailjs, { EmailJSResponseStatus } from 'emailjs-com';
@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css']
})
export class ContactUsComponent{
  public sendEmail(e: Event) {
    e.preventDefault();
    emailjs.sendForm('service_v2bvq0h', 'template_d8hoiul', e.target as HTMLFormElement, 'user_EQxzhd1kES8Lhjv21zZOC')
      .then((result: EmailJSResponseStatus) => {
        console.log(result.text);
        this.router.navigate(['email-status']);
      }, (error) => {
        console.log(error.text);
      });
  }

  constructor(private router: Router) { }

  ngOnInit(): void {
    
  }

}
