import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AccountRoutingModule } from './account-routing.module';
import { QuestionnaireComponent } from '../pet/questionnaire/questionnaire.component';
import { PlansComponent } from '../pet/plans/plans.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AccountService } from './account.service';
import { HttpClientModule } from '@angular/common/http';
import { QuoteComponent } from '../pet/quote/quote.component';
import { PurchaseComponent } from '../pet/purchase/purchase.component';
import { PurchaseStatusComponent } from '../pet/purchase-status/purchase-status.component';
import { CustAccountComponent } from './cust-account/cust-account.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { EmailStatusComponent } from './email-status/email-status.component';



@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    QuestionnaireComponent,
    PlansComponent,
    QuoteComponent,
    PurchaseComponent,
    PurchaseStatusComponent,
    CustAccountComponent,
    ContactUsComponent,
    AboutUsComponent,
    EmailStatusComponent
  ],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    HttpClientModule,
    AccountRoutingModule
  ],
  providers: []
})
export class AccountModule { }
