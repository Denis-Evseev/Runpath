import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../models/user';

@Component({
  selector: 'app-home',
  templateUrl: './users.component.html',
})
export class UsersComponent {

  public users: User[];

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string) {
    http.get<User[]>(baseUrl + 'api/Users/GetUsers').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }
}

