import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {User} from "./user.model";

@Injectable()
export class UserService {
  constructor(private http: HttpClient) { }
  baseUrl: string = '/api/users';		//will be provided

  getUsers() {
    return this.http.get<User[]>(this.baseUrl);
  }

  getUserById(id: number) {
    return this.http.get<User>(this.baseUrl + '/' + id);
  }

  createUser(user: User) {
    return this.http.post(this.baseUrl, user);
  }

  updateUser(user: User) {
    return this.http.put(this.baseUrl + '/' + user.id, user);
  }

}
