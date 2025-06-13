import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { User } from '../_models/user';
import { map } from 'rxjs';

  @Injectable({
  providedIn: 'root'
  })
  export class AccountService {
  private http = inject(HttpClient);
   baseUrl = 'https://localhost:5001/api';

   currentUser = signal<User | null>(null);

  login(model: any) {
    return this.http.post(this.baseUrl + '/account/login', model).pipe(
      map(user => {
        if (user) {
          const typedUser = user as User;
          localStorage.setItem('user', JSON.stringify(typedUser));
          this.currentUser.set(typedUser);
        }
      }
    ));
   }
   register(model: any) {
    return this.http.post(this.baseUrl + '/account/register', model).pipe(
      map(user => {
        if (user) {
          const typedUser = user as User;
          localStorage.setItem('user', JSON.stringify(typedUser));
          this.currentUser.set(typedUser);
        }
        return user;
      }
    ));
   }

   logout() {
    localStorage.removeItem('user');
    this.currentUser.set(null);}
}
