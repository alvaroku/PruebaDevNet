import { Component } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { LoginResponse, MenuResponse } from '../../../models/models';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-menu',
  imports: [RouterOutlet, RouterLink, CommonModule],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent {
  currentUser: LoginResponse | null = null;

  menuItems: MenuResponse[] = []
  constructor(

    authService: AuthService,
    router: Router) {

    authService.currentUser$.subscribe((x: LoginResponse | null) => {
      this.currentUser = x;
      if (!x) {
        router.navigate(["/login"])
      }
      this.menuItems = this.currentUser?.menus??[]
    });
  }
}
