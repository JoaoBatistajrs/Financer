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
    { routerLink: 'register', icon: 'keyboard_arrow_right', label: 'Registers' },
    { routerLink: 'bank', icon: 'keyboard_arrow_right', label: 'Banks' },
    { routerLink: 'category', icon: 'keyboard_arrow_right', label: 'Categories' },
    { routerLink: 'register-type', icon: 'keyboard_arrow_right', label: 'Register Type' },
    { routerLink: 'expense', icon: 'keyboard_arrow_right', label: 'Expenses' },
  ];

  toggle() {
    this.isOpen = !this.isOpen;
  }
}
