import { NgModule, Component } from "@angular/core";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { Routes, RouterModule } from "@angular/router";

import { AdminLayoutComponent } from "./layouts/admin-layout/admin-layout.component";
import { AuthLayoutComponent } from './layouts/auth-layout/auth-layout.component';
import { HomeComponent } from './pages/home/home.component';
import { SignInComponent } from './pages/sign-in/sign-in.component';
import { SignUpComponent } from './pages/sign-up/sign-up.component';
import { NotFoundComponent } from './pages/not-found/not-found.component';
import { AccessDeniedComponent } from './pages/access-denied/access-denied.component';

const routes: Routes = [
  { path: "home" , component : HomeComponent },

  {
    path: "",
    redirectTo: "home",
    pathMatch: "full"
  },
  {
    path: "",
    component: AdminLayoutComponent,
    children: [
      {
        path: "",
        loadChildren:
          "./layouts/admin-layout/admin-layout.module#AdminLayoutModule"
      }
    ]
  }, 
  // {
  //   path: '',
  //   component: AuthLayoutComponent,
  //   children: [
  //     {
  //       path: '',
  //       loadChildren: './layouts/auth-layout/auth-layout.module#AuthLayoutModule'
  //     }
  //   ]
  // },
 
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes, {
      useHash: true
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
