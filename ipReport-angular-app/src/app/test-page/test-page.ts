import { Component, OnInit } from '@angular/core';
import { inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-test-page',
  standalone: false,
  templateUrl: './test-page.html',
  styleUrl: './test-page.scss',
})
export class TestPage implements OnInit {
  readonly _httpClient = inject(HttpClient);
  public forecasts: Observable<any[]> | undefined;

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.forecasts = this._httpClient.get<any[]>('/api/weatherforecast');
  }

}
