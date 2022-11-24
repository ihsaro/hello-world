import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NewExampleGridComponent } from './new-example-grid/new-example-grid.component';
import { NewExampleComponent } from './new-example/new-example.component';

export interface Example {
  id: Number;
  name: string;
  age: Number;
  address: string;
  gender: string;
}


@Component({
  selector: 'app-example',
  templateUrl: './example.component.html',
  styleUrls: ['./example.component.css']
})
export class ExampleComponent implements AfterViewInit {

  examples: Example[] = [
    {
      id: 1,
      name: "tom",
      address: "Mauritius",
      age: 20,
      gender: "Male"
    },
    {
      id: 2,
      name: "tim",
      address: "Mauritius",
      age: 20,
      gender: "Male"
    },
    {
      id: 3,
      name: "tam",
      address: "Mauritius",
      age: 20,
      gender: "Male"
    },
    {
      id: 4,
      name: "wom",
      address: "Mauritius",
      age: 20,
      gender: "Male"
    },
    {
      id: 5,
      name: "som",
      address: "Mauritius",
      age: 20,
      gender: "Male"
    },
    {
      id: 6,
      name: "zom",
      address: "Mauritius",
      age: 20,
      gender: "Male"
    },
    {
      id: 7,
      name: "nom",
      address: "Mauritius",
      age: 20,
      gender: "Male"
    },
  ]

  displayedColumns: string[] = ['id', 'name', 'address', 'age','actions'];
  dataSource: MatTableDataSource<Example>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(public dialog: MatDialog) {
    this.dataSource = new MatTableDataSource(this.examples);
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  openDialog(): void {
    this.dialog.open(NewExampleGridComponent, {
      width: '650px',
      enterAnimationDuration: '400ms',
      exitAnimationDuration:'200ms',
      autoFocus: false
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
 }


