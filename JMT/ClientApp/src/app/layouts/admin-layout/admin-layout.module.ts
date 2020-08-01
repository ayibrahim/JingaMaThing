import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";

import { AdminLayoutRoutes } from "./admin-layout.routing";
import { DashboardComponent } from "../../pages/dashboard/dashboard.component";

import {DialogModule} from 'primeng/dialog';
import {TableModule} from 'primeng/table';
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import {SharedModule} from 'primeng';
import {CalendarModule} from 'primeng/calendar';
import {GalleriaModule} from 'primeng/galleria';
import {InputTextModule} from 'primeng/inputtext';
import {PaginatorModule} from 'primeng/paginator';
import {CardModule} from 'primeng/card';
import {OverlayPanelModule} from 'primeng/overlaypanel';
import {OrderListModule} from 'primeng/orderlist';
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    HttpClientModule,
    SharedModule,
    GalleriaModule,
    OrderListModule,
    OverlayPanelModule,
    CalendarModule,
    PaginatorModule,
    CardModule,
    DialogModule,
    InputTextModule,
    TableModule,
    NgbModule,
  ],
  declarations: [
    DashboardComponent,

    // RtlComponent
  ]
})
export class AdminLayoutModule {}
