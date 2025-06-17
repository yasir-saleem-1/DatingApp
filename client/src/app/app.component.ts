
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./nav/nav.component";
import { AccountService } from './_services/account.service';
import { HomeComponent } from "./home/home.component";
import { NgxSpinnerModule } from 'ngx-spinner';

@Component({
    selector: 'app-root',
    //imports: [RouterOutlet , NgFor],
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [RouterOutlet, NavComponent, NgxSpinnerModule]
})
export class AppComponent implements OnInit {
  

    private accountService = inject(AccountService);
      ngOnInit(): void {
        this.setCurrentUser();
      }
      
      setCurrentUser() {
        const userString = localStorage.getItem('user');
        if (userString) {
          const user = JSON.parse(userString);
          this.accountService.currentUser.set(user);
        }
      }

      
}
