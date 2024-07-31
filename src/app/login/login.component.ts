import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  role: string = '';
  error: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  login() {
    console.log("Username: ", this.username, "Password: ", this.password, "Role: ", this.role);
    if (this.authService.login(this.username, this.password)) {
      const user = this.authService.getUser();
      console.log("Logged in user: ", user);
      if (user.role === this.role) {
        if (this.role === 'admin') {
          console.log("Redirecting to Admin Dashboard");
          this.router.navigate(['/admin']);
        } else if (this.role === 'service-advisor') {
          console.log("Redirecting to Service Advisor Dashboard");
          this.router.navigate(['/service-advisor']);
        }
      } else {
        console.log("Error: Invalid role selected");
        this.error = 'Invalid role selected';
      }
    } else {
      console.log("Error: Invalid username or password");
      this.error = 'Invalid username or password';
    }
  }
}
