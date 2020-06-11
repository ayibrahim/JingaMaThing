import { Routes } from "@angular/router";

import { DashboardComponent } from "../../pages/dashboard/dashboard.component";
import { IconsComponent } from "../../pages/icons/icons.component";
import { MapComponent } from "../../pages/map/map.component";
import { NotificationsComponent } from "../../pages/notifications/notifications.component";
import { TablesComponent } from "../../pages/tables/tables.component";
import { TypographyComponent } from "../../pages/typography/typography.component";
import { HomeComponent } from 'src/app/pages/home/home.component';
import { UserProfileComponent } from 'src/app/pages/user-profile/user-profile.component';
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
  // { path: "rtl", component: RtlComponent }
];
