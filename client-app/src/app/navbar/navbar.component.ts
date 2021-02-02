import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from '../services/account.service';
import { User } from '../models/user';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  model: any = {}
  loggedIn: boolean;


  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
  }

  login(){
    this.accountService.login(this.model).subscribe(response => {
      console.log(response);
      this.loggedIn = true;
    }, error => {
      console.log(error);
    })
  }

  logout(){
    this.accountService.logout();
  }

}
