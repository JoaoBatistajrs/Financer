import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { BankService } from '../../services/banks.service';
import { Bank } from '../../models/bank';

@Component({
  selector: 'app-sidenav',
  standalone: true,
  imports: [MatSidenavModule, MatButtonModule],
  templateUrl: './sidenav.component.html',
  styleUrl: './sidenav.component.scss'
})
export class SidenavComponent implements OnInit {
  showFiller = false;
  bankData: Bank[] = [];

  constructor(private bankService: BankService) { }

  ngOnInit(): void {
    this.bankService.getAll().subscribe({
      next: data => {
        console.log('Data received:', data);
      },
      error: error => {
        console.error('There was an error!', error);
      }
    });
  }
}
