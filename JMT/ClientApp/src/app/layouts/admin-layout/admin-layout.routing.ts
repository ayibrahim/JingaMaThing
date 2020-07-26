import { Routes } from "@angular/router";

import { DashboardComponent } from "../../pages/dashboard/dashboard.component";
import { IconsComponent } from "../../pages/icons/icons.component";
import { MapComponent } from "../../pages/map/map.component";
import { NotificationsComponent } from "../../pages/notifications/notifications.component";
import { TablesComponent } from "../../pages/tables/tables.component";
import { TypographyComponent } from "../../pages/typography/typography.component";
import { HomeComponent } from 'src/app/pages/home/home.component';
import { UserProfileComponent } from 'src/app/pages/user-profile/user-profile.component';
import { EmailComponent } from 'src/app/pages/email/email.component';
import { NewOrderComponent } from 'src/app/pages/new-order/new-order.component';
import { DevordersComponent } from 'src/app/pages/devorders/devorders.component';
import { CustomerordersComponent } from 'src/app/pages/customerorders/customerorders.component';
// import { RtlComponent } from "../../pages/rtl/rtl.component";

export const AdminLayoutRoutes: Routes = [

  { path: "dashboard", component: DashboardComponent},
  { path: "home", component: HomeComponent },
  { path: "icons", component: IconsComponent },
  { path: "maps", component: MapComponent },
  { path: "notifications", component: NotificationsComponent },
  { path: "user-profile", component: UserProfileComponent },
  { path: "tables", component: TablesComponent },
  { path: "typography", component: TypographyComponent },
  { path: "email" , component : EmailComponent},
  { path: "new-order" , component : NewOrderComponent},
  { path: "devorders" , component : DevordersComponent},
  { path: "customerorders" , component : CustomerordersComponent},
  
  // { path: "rtl", component: RtlComponent }
];
