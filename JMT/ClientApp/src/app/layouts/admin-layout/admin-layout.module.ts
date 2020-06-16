import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

import { AdminLayoutRoutes } from "./admin-layout.routing";
import { DashboardComponent } from "../../pages/dashboard/dashboard.component";
import { IconsComponent } from "../../pages/icons/icons.component";
import { MapComponent } from "../../pages/map/map.component";
import { NotificationsComponent } from "../../pages/notifications/notifications.component";

import { TablesComponent } from "../../pages/tables/tables.component";
import { TypographyComponent } from "../../pages/typography/typography.component";
// import { RtlComponent } from "../../pages/rtl/rtl.component";
import {DialogModule} from 'primeng/dialog';
import {TableModule} from 'primeng/table';
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import {SharedModule} from 'primeng';
import {CalendarModule} from 'primeng/calendar';
import {GalleriaModule} from 'primeng/galleria';
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    HttpClientModule,
    SharedModule,
    GalleriaModule,
    CalendarModule,
    DialogModule,
    TableModule,
    NgbModule,
  ],
  declarations: [
    DashboardComponent,
    TablesComponent,
    IconsComponent,
    TypographyComponent,
    NotificationsComponent,
    MapComponent,
    // RtlComponent
  ]
})
export class AdminLayoutModule {}
