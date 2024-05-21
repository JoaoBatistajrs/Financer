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
    // { routerLink: '', icon: 'build', label: 'tes1' },
    // { routerLink: '', icon: 'linear_scale', label: 'test2' },
    // { routerLink: '', icon: 'settings', label: 'tes3' },
    // { routerLink: '', icon: 'engineering', label: 'test4' },
    // { routerLink: '', icon: 'lock', label: 'test5' }
  ];

  toggle() {
    this.isOpen = !this.isOpen;
  }
}
