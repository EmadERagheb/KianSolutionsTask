import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
    private http= inject(HttpClient)
    private router= inject(Router)
  currentUser = signal<User | null>(null);

  
}
