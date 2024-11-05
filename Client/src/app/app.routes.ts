import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { SliderComponent } from './slider/slider.component';
import { EmployeesListComponent } from './employee/employees-list/employees-list.component';

export const routes: Routes = [
   { path:'',component: HomeComponent,children:[
       {path: '', redirectTo: 'home', pathMatch: 'full'},
       {path: 'home', component: SliderComponent},
       {path:'employees',component:EmployeesListComponent},

   ]},
    { path: 'server-error', component: ServerErrorComponent },
    { path: 'not-found', component: NotFoundComponent },
    {path:"**", redirectTo: 'home'},
];
