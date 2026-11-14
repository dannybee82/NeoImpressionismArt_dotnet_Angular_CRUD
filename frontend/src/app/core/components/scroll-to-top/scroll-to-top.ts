import { ViewportScroller } from '@angular/common';
import { Component, HostListener, OnDestroy, WritableSignal, inject, signal } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-scroll-to-top',
  templateUrl: './scroll-to-top.html',
  styleUrls: ['./scroll-to-top.scss'],
  imports: [MatIconModule],
})
export class ScrollToTop {
  protected isVisible: WritableSignal<boolean> = signal(false);

  private scroller = inject(ViewportScroller);

  @HostListener('window:scroll')
  onWindowScroll(): void {
    let pos: number =
        (document.documentElement.scrollTop || document.body.scrollTop);
    let max = document.documentElement.scrollHeight;

    this.isVisible.set(pos > 1 ? true : false); 
  }

  scrollToTop(): void {
    this.isVisible.set(false);
    this.scroller.scrollToPosition([0, 0], { behavior: 'smooth' }); 
  }
}
