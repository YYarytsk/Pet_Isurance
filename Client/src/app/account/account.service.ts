import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { filter, shareReplay } from 'rxjs/operators';
import { SharedService } from '../shared/shared.service';
import { LoginRequest } from './loginRequest';
import { User } from './user';


@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private userSubject: BehaviorSubject<User | null> = new BehaviorSubject<User | null>(null);
  user$: Observable<User | null> = this.userSubject.asObservable().pipe(shareReplay(1));

  constructor(private sharedService: SharedService, private https: HttpClient, private router: Router) { }

  init(): void {
    const serializedUser: string | null = localStorage.getItem('user');
    if (serializedUser) {
      const localUser: User = JSON.parse(serializedUser)
      this.userSubject.next(localUser);
    }
  }
  isLogged() {
    if (this.userSubject.value) {
      return true;
    }
    else return false;
  }
  logIn(user: LoginRequest) {
    this.sharedService.logInUser(user).subscribe((user: User | null) => {
      this.userSubject.next(user);
      localStorage.setItem('user', JSON.stringify(user))
      this.router.navigate(['logged']);
      return user;
    });
  }
  getUser() {
    if (this.userSubject.value) {
      return (this.userSubject.value as User)
    }
    else {
      return null;
    }
  }
  register(user: User) {
    console.log("register", user);
    return this.sharedService.registerUser(user);
  }
  // Log out method
  logOut() {
    this.userSubject.next(null);
    localStorage.clear();
  }
}