import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Spinner } from './core/components/spinner/spinner';
import { ScrollToTop } from './core/components/scroll-to-top/scroll-to-top';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Spinner, ScrollToTop],
  template: `
    <app-spinner />
    <router-outlet />
    <app-scroll-to-top />
  `
})
export class App {
  protected readonly title = signal('NeoImpressionismArtAngularFrontend');
}
