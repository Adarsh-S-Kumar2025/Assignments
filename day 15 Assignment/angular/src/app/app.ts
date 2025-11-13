import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,FormsModule,CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  states = [
    { state: 'Andhra', cm: 'Jagan', capital: 'Amaravati' },
    { state: 'Telangana', cm: 'KCR', capital: 'Hyderabad' },
    { state: 'Karnataka', cm: 'Bommai', capital: 'Bangalore' },
    { state: 'Maharashtra', cm: 'Uddhav Thackeray', capital: 'Mumbai' },
    { state: 'Kerala', cm: 'Pinnarayi', capital: 'Trivandrum' },
  ];

  colorList = ['One', 'Two', 'Three', 'Four', 'Five', 'Six'];

  blockList = [
    { num: '1', child: ['1.1', '1.2'] },
    { num: '2', child: ['2.1', '2.2', '2.3'] }
  ];

  showAlert() {
    alert('Hello World');
  }

  isLeapYear(year: number): string {
    if ((year % 4 === 0 && year % 100 !== 0) || (year % 400 === 0)) {
      return `${year} is a Leap Year.`;
    } else {
      return `${year} is NOT a Leap Year.`;
    }
  }

  ngOnInit() {
    console.log(this.isLeapYear(2024));
    console.log(this.isLeapYear(2025));
  }
}
