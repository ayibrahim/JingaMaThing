import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { ToastrModule } from 'ngx-toastr';

import { AppComponent } from "./app.component";
import { AdminLayoutComponent } from "./layouts/admin-layout/admin-layout.component";
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';

import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { AppRoutingModule } from "./app-routing.module";
import { ComponentsModule } from "./components/components.module";
import { HomeComponent } from './pages/home/home.component';
import { AngularTiltModule } from 'angular-tilt';
import { SignInComponent } from './pages/sign-in/sign-in.component';
import { SignUpComponent } from './pages/sign-up/sign-up.component';
import { Globals } from './Shared/globals';
import {BrowserModule} from '@angular/platform-browser';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ComponentsModule,
    NgbModule,
    RouterModule,
    AngularTiltModule,
    AppRoutingModule,
    BrowserModule,
    ToastrModule.forRoot(),

  ],
  declarations: [AppComponent, AdminLayoutComponent, AuthLayoutComponent, HomeComponent, SignInComponent, SignUpComponent],
  providers: [Globals],
  bootstrap: [AppComponent]
})
export class AppModule {}
