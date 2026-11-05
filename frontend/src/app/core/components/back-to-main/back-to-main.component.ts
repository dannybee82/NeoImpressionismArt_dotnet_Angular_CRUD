import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';

// Angular Material Modules
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
	imports: [MatButtonModule, MatIconModule],
  selector: 'app-back-to-main',
  templateUrl: './back-to-main.component.html',
  styleUrls: ['./back-to-main.component.scss']
})
export class BackToMainComponent {

	private router = inject(Router);

  goBackToMain() : void {
    this.router.navigate(['']);
  }

}