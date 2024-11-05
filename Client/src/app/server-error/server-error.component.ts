import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment.development';

@Component({
  selector: 'app-server-error',
  standalone: true,
  imports: [],
  templateUrl: './server-error.component.html',
  styleUrl: './server-error.component.scss'
})
export class ServerErrorComponent {
  isProduction:boolean=environment.production
  router= inject(Router)
  error = this.router.getCurrentNavigation()?.extras?.state?.['error'];
}
