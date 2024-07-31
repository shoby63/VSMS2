import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isLoggedIn = false;
  private user: { username: string, role: string } = {
    username:"admin",
    role:'admin'
  };

  constructor(private router: Router) {
    this.loadUserFromLocalStorage();
  }

  login(username: string, password: string): boolean {
    // Replace this logic with actual authentication logic
    if (username === 'admin' && password === 'admin') {
      this.user = { username, role: 'admin' };
      this.isLoggedIn = true;
      this.saveUserToLocalStorage();
      return true;
    } else if (username === 'advisor' && password === 'advisorpass') {
      this.user = { username, role: 'service-advisor' };
      this.isLoggedIn = true;
      this.saveUserToLocalStorage();
      return true;
    }
    return false;
  }

  logout() {
    this.isLoggedIn = false;
    this.user = {
      username:"",
      role:""
    };
    this.clearLocalStorage();
    this.router.navigate(['/login']);
  }

  getUser() {
    return this.user;
  }

  isAuthenticated(): boolean {
    return this.isLoggedIn;
  }

  private saveUserToLocalStorage() {
    if (this.user) {
      localStorage.setItem('user', JSON.stringify(this.user));
      localStorage.setItem('isLoggedIn', JSON.stringify(this.isLoggedIn));
    }
  }

  private loadUserFromLocalStorage() {
    const user = localStorage.getItem('user');
    const isLoggedIn = localStorage.getItem('isLoggedIn');

    if (user && isLoggedIn) {
      this.user = JSON.parse(user);
      this.isLoggedIn = JSON.parse(isLoggedIn);
    }
  }

  private clearLocalStorage() {
    localStorage.removeItem('user');
    localStorage.removeItem('isLoggedIn');
  }
}
