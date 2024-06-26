import { AfterViewInit, ChangeDetectorRef, Component, EventEmitter, Input, Output, SimpleChanges, ViewChild } from '@angular/core';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input'
import { MatPaginatorModule, MatPaginator } from '@angular/material/paginator';
import { MatSortModule, MatSort } from '@angular/material/sort';
import { CommonModule, CurrencyPipe } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatTooltipModule } from '@angular/material/tooltip';


@Component({
  selector: 'app-datatable',
  templateUrl: './datatable.component.html',
  styleUrls: ['./datatable.component.scss'],
  standalone: true,
  providers: [CurrencyPipe],
  imports: [MatProgressBarModule, MatTableModule, MatPaginatorModule, MatSortModule, CommonModule, MatFormFieldModule, MatInputModule, MatCardModule, MatToolbarModule, MatIconModule, MatButtonModule, MatCheckboxModule, MatTooltipModule]
})
export class DatatableComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @Input('dataColumns') dataColumns!: string[];
  @Input('columnNames') columnNames!: string[];
  @Input('dataToDisplay') dataToDisplay!: any[];
  @Input() searchedFor: string | null = '';
  @Input() shouldShowSearchedFor: boolean = false;
  @Input() shouldShowSearchForAndItemsFound: boolean = false;
  @Input('showManagementeColumn') shouldShowManagementColumn: boolean = false;
  @Input('shouldShowCheckboxColumn') shouldShowCheckboxColumn : boolean = false;
  @Output() editItemClicked: EventEmitter<any> = new EventEmitter<any>();
  @Output() removeItemClicked: EventEmitter<any> = new EventEmitter<any>();
  @Output() checkboxChangeEvent: EventEmitter<any> = new EventEmitter<any>();

  constructor(private cdr: ChangeDetectorRef) { }

  dataSource = new MatTableDataSource();
  loading: boolean = true;

  ngAfterViewInit(): void {
    this.dataSource.data = this.dataToDisplay;
    this.dataSource.sortingDataAccessor = (item, header) => this.getSortingData(item, header);
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.loading = true;
    if (changes['dataToDisplay'] && changes['dataToDisplay'].currentValue) {
      this.dataSource.data = this.dataToDisplay;
      this.loading = false;
    }
    this.cdr.detectChanges();
  }

  applyFilter(event: Event){
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if(this.dataSource.paginator){
      this.dataSource.paginator.firstPage();
    }
  }

  getSortingData(item: any, header: string): any {
    return header === 'colName' ? item[header].toLowerCase() : item[header].toLowerCase();
  }

  editItem(item: any): void {
    this.editItemClicked.emit(item);
  }

  removeItem(item: any): void {
    this.removeItemClicked.emit(item);
  }

  checkboxChanged(item: any): void {
    this.checkboxChangeEvent.emit(item);
  }

  isNumber(value: any): boolean {
    return typeof value === 'number';
  }
}
