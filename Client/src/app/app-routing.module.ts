import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmailStatusComponent } from './account/email-status/email-status.component';
import { PurchaseStatusComponent } from './pet/purchase-status/purchase-status.component';
import { PurchaseComponent } from './pet/purchase/purchase.component';
import { QuestionnaireComponent } from './pet/questionnaire/questionnaire.component';


const routes: Routes = [

  { path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule) },
  { path: 'logged', component: QuestionnaireComponent },
  {path: 'email-status', component: EmailStatusComponent},
  {path: 'purchase', component: PurchaseComponent},
  {path: 'purchase-status', component: PurchaseStatusComponent}



];
@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
