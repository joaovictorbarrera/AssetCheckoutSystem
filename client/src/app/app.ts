import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PageLoadingService } from './core/services/util/page-loading.service';
import { SpinningWheel } from './core/components/spinning-wheel/spinning-wheel';
import { AuthService } from './core/services/api/auth.service';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, SpinningWheel],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit {
  constructor(
    readonly pageLoading: PageLoadingService,
    readonly authService: AuthService,
  ) {}

  ngOnInit(): void {
    this.authService.initializeAuth()
  }
}
