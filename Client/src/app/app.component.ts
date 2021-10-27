import { Component } from '@angular/core';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private userService: AccountService) { }

  ngOnInit(): void {
    this.userService.init();
  }
  title = 'Pet Insurance';
}
