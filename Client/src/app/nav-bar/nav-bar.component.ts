import { Component, Input, OnInit } from '@angular/core';
import { AccountService } from '../account/account.service';
import { User } from '../account/user';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {


  @Input() user!: User | null;

  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
    this.user = this.accountService.getUser();
  }
}
