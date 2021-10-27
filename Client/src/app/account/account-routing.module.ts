import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { QuestionnaireComponent } from '../pet/questionnaire/questionnaire.component';
import { PlansComponent } from '../pet/plans/plans.component';
import { QuoteComponent } from '../pet/quote/quote.component';
import { PurchaseComponent } from '../pet/purchase/purchase.component';
import { PurchaseStatusComponent } from '../pet/purchase-status/purchase-status.component';
import { CustAccountComponent } from './cust-account/cust-account.component';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { EmailStatusComponent } from './email-status/email-status.component';

const routes: Routes = [
  { path: '', redirectTo: 'questionnaire', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'questionnaire', component: QuestionnaireComponent },
  { path: 'plans', component: PlansComponent },
  { path: 'quote', component: QuoteComponent },
  { path: 'purchase', component: PurchaseComponent },
  { path: 'purchase-status', component: PurchaseStatusComponent },
  { path: 'cust-account', component: CustAccountComponent },
  { path: 'contact-us', component: ContactUsComponent },
  { path: 'about-us', component: AboutUsComponent },
  { path: 'logged', component: QuestionnaireComponent },
  {path: 'email-status', component: EmailStatusComponent}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
