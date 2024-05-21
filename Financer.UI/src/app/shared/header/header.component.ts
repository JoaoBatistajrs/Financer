import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { SidenavComponent } from '../sidenav/sidenav.component';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [MatIconModule, MatButtonModule, MatToolbarModule, SidenavComponent],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  isLastPage: boolean = true;

  onMenuButtonClick(sidenav: any) {
    sidenav.toggle();
    this.toggleIcon();
  }

  toggleIcon() {
    this.isLastPage = !this.isLastPage;
  }
}
