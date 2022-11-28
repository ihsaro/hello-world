import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: []
})
export class AppHeaderComponent {

  constructor(private route: Router) {}

  logout() {
    this.route.navigate(['login'])
  }
}


