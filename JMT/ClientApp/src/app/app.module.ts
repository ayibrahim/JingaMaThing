import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from "./app.component";
import { AdminLayoutComponent } from "./layouts/admin-layout/admin-layout.component";
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import {DataViewModule} from 'primeng/dataview';
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { AppRoutingModule } from "./app-routing.module";
import { ComponentsModule } from "./components/components.module";
import { HomeComponent } from './pages/home/home.component';
import { AngularTiltModule } from 'angular-tilt';
import { SignInComponent } from './pages/sign-in/sign-in.component';
import { SignUpComponent } from './pages/sign-up/sign-up.component';
import { Globals } from './Shared/globals';
import {BrowserModule} from '@angular/platform-browser';
import { UserProfileComponent } from './pages/user-profile/user-profile.component'; 
import {SharedModule} from 'primeng';
import {CalendarModule} from 'primeng/calendar';
import {GalleriaModule} from 'primeng/galleria';
import {DialogModule} from 'primeng/dialog';
import {TableModule} from 'primeng/table';
import {InputTextModule} from 'primeng/inputtext';
import {PaginatorModule} from 'primeng/paginator';
import { EmailComponent } from './pages/email/email.component';
import {TabMenuModule} from 'primeng/tabmenu';
import {DropdownModule} from 'primeng/dropdown';
import { NewOrderComponent } from './pages/new-order/new-order.component';
import {InputNumberModule} from 'primeng/inputnumber';
import { DevordersComponent } from './pages/devorders/devorders.component';
import {CardModule} from 'primeng/card';
import {OverlayPanelModule} from 'primeng/overlaypanel';
import {ToggleButtonModule} from 'primeng/togglebutton';
import { CustomerordersComponent } from './pages/customerorders/customerorders.component';
import { CustomerDashboardComponent } from './pages/customer-dashboard/customer-dashboard.component';
import {OrderListModule} from 'primeng/orderlist';
import { NotesComponent } from './pages/notes/notes.component';
import { LinksComponent } from './pages/links/links.component';
import {SelectButtonModule} from 'primeng/selectbutton';
import {InputTextareaModule} from 'primeng/inputtextarea';
import {RatingModule} from 'primeng/rating';
import {EditorModule} from 'primeng/editor';
import {BlockUIModule} from 'primeng/blockui';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ComponentsModule,
    TabMenuModule,
    ToggleButtonModule,
    EditorModule,
    NgbModule,
    RouterModule,
    SelectButtonModule,
    BlockUIModule,
    RatingModule,
    AngularTiltModule,
    InputTextareaModule,
    AppRoutingModule,
    InputNumberModule,
    OrderListModule,
    OverlayPanelModule,
    BrowserModule,
    DataViewModule,
    SharedModule,
    DropdownModule,
    CardModule,
    CalendarModule,
    TableModule,
    PaginatorModule,
    DialogModule,
    InputTextModule,
    GalleriaModule,
    ToastrModule.forRoot(),

  ],
  declarations: [AppComponent, AdminLayoutComponent, AuthLayoutComponent, HomeComponent, SignInComponent, SignUpComponent, UserProfileComponent, EmailComponent , NewOrderComponent, DevordersComponent, CustomerordersComponent, CustomerDashboardComponent, NotesComponent, LinksComponent ],
  providers: [Globals],
  bootstrap: [AppComponent]
})
export class AppModule {}
