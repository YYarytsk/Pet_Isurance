
import { Injectable } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { LoginRequest } from '../account/loginRequest';

import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { User } from '../account/user';
import { Pet } from '../pet/pet';
import { quoteDisplay } from '../pet/quoteDisplay';



@Injectable({
  providedIn: 'root'
})
export class SharedService {
  private readonly APIUrl = environment.dbURL;
  constructor(private https: HttpClient) { }


  payForInsurance(pets: Pet[]): Observable<Pet[]> {
    console.log("inside service");
    var k = this.https.put<Pet[]>(this.APIUrl + '/Pets/Purchase', pets)
    k.subscribe(p => {
      console.log(p);
      return p;
    }, err => {
      return err;
    })
    return k;
  }

  registerUser(user: User): Observable<User> {
    return this.https.post<User>(this.APIUrl + '/Users/Register', user);
  }

  getQuote(pets: Pet[]): Observable<quoteDisplay[]> {
    console.log("inside serv", pets)
    return this.https.post<quoteDisplay[]>(this.APIUrl + '/Pets/QuotePets', pets);
  }


  addPet(pet: Pet): Observable<Pet[]> {
    console.log(pet);
    return this.https.post<Pet[]>(this.APIUrl + '/Pets', pet);
  }

  getPets(user: User): Observable<Pet[]> {
    return this.https.get<Pet[]>(this.APIUrl + `/Pets/${user.id}`);
  }

  logInUser(loginRequest: LoginRequest): Observable<User> {
    return this.https.post<User>(this.APIUrl + '/Users/Login', loginRequest);
  }
}