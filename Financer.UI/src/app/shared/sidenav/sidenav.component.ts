import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-sidenav',
  standalone: true,
  imports: [CommonModule, MatSidenavModule, MatIconModule, MatListModule, RouterOutlet, RouterLink],
  templateUrl: './sidenav.component.html',
  styleUrl: './sidenav.component.scss'
})

export class SidenavComponent {
  isOpen = true;

  navItems = [
    { routerLink: 'bank', icon: 'build', label: 'Banks' },
    { routerLink: 'register', icon: 'build', label: 'Registers' },
    { routerLink: 'expense', icon: 'linear_scale', label: 'Expenses' },
    { routerLink: 'category', icon: 'settings', label: 'Categories' },
    { routerLink: 'register-type', icon: 'engineering', label: 'Register Type' },
  ];

  toggle() {
    this.isOpen = !this.isOpen;
  }
}
