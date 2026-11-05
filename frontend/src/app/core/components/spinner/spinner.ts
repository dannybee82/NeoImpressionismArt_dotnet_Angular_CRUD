import { Component, inject, OnInit, signal, WritableSignal } from '@angular/core';
import { Loading } from '../../services/loading/loading';

@Component({
  imports: [],
  selector: 'app-spinner',
  styleUrl: './spinner.scss',
  templateUrl: './spinner.html',
})
export class Spinner  implements OnInit {

  protected showSpinner: WritableSignal<boolean> = signal(false);

  private loadingService = inject(Loading);

  ngOnInit(): void {
    this.loadingService.isLoading.subscribe((isLoading: boolean) => {
      this.showSpinner.set(isLoading);
    });
  }

}