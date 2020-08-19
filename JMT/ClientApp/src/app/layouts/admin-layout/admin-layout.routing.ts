import { Routes } from "@angular/router";

import { DashboardComponent } from "../../pages/dashboard/dashboard.component";
import { HomeComponent } from 'src/app/pages/home/home.component';
import { UserProfileComponent } from 'src/app/pages/user-profile/user-profile.component';
import { EmailComponent } from 'src/app/pages/email/email.component';
import { NewOrderComponent } from 'src/app/pages/new-order/new-order.component';
import { DevordersComponent } from 'src/app/pages/devorders/devorders.component';
import { CustomerordersComponent } from 'src/app/pages/customerorders/customerorders.component';
import { CustomerDashboardComponent } from 'src/app/pages/customer-dashboard/customer-dashboard.component';
import { LinksComponent } from 'src/app/pages/links/links.component';
import { NotesComponent } from 'src/app/pages/notes/notes.component';
import { RmdevelopersComponent } from 'src/app/pages/rmdevelopers/rmdevelopers.component';
import { RmordersComponent } from 'src/app/pages/rmorders/rmorders.component';
// import { RtlComponent } from "../../pages/rtl/rtl.component";

export const AdminLayoutRoutes: Routes = [
  { path: "home", component: HomeComponent },
  { path: "user-profile", component: UserProfileComponent },
  { path: "email" , component : EmailComponent},
  { path: "new-order" , component : NewOrderComponent},
  { path: "devorders" , component : DevordersComponent},
  { path: "customerorders" , component : CustomerordersComponent},
  { path: "customerdashboard" , component : CustomerDashboardComponent},
  { path: "notes" , component : NotesComponent},
  { path: "links" , component : LinksComponent},
  { path: "rmdevelopers" , component : RmdevelopersComponent},
  { path: "rmorders" , component : RmordersComponent}
  
  // { path: "rtl", component: RtlComponent }
];
