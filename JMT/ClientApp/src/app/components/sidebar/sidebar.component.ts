import { Component, OnInit, Input } from "@angular/core";
import { Router } from '@angular/router';

declare interface RouteInfo {
  path: string;
  title: string;

  icon: string;
  class: string;
}
export class customer{
  FirstName : string; LastName : string; Email : string; Password: string; CustomerID : number; PhoneNumber : string; RoleDesc : string;
}
export class Dev{
  FirstName : string; LastName : string; Email : string; Password: string; DeveloperID : number; PhoneNumber : string;  RoleDesc : string; Description : string; PLanguages : string;
  Skills : string; Education : string; Certification : string; Title : string;
}
export var ROUTES: RouteInfo[] = [
  
];


@Component({
  selector: "app-sidebar",
  templateUrl: "./sidebar.component.html",
  styleUrls: ["./sidebar.component.css"]
})

export class SidebarComponent implements OnInit {
  menuItems: any[];
  @Input() custfull : customer = new customer();
  @Input() devfull : Dev = new Dev();
  iscustomer : boolean  = false;
  isdeveloper : boolean = false;
  constructor() {}
  
  ngOnInit() {
    if(this.custfull.FirstName == undefined){
      this.isdeveloper = true;
    }
    if(this.devfull.FirstName == undefined){
      this.iscustomer = true;
    }
    if(this.isdeveloper == true){
      ROUTES = [
        {
          path: "/dashboard",
          title: "Dashboard",
          icon: "icon-chart-pie-36",
          class: ""
        },
        {
          path: "/icons",
          title: "Orders",
          icon: "icon-cart",
          class: ""
        },
        {
          path: "/maps",
          title: "New Order",
          icon: "icon-bag-16",
          class: "" },
        {
          path: "/notifications",
          title: "Chat",
          icon: "icon-chat-33",
          class: ""
        },
      
        {
          path: "/user-profile",
          title: "Profile",
          icon: "icon-single-02",
          class: ""
        },
        {
          path: "/tables",
          title: "Logout",
          icon: "icon-lock-circle",
          class: ""
        }
      ];
  }
  if(this.iscustomer == true){
    ROUTES = [
      {
        path: "/dashboard",
        title: "Dashboard",
        icon: "icon-chart-pie-36",
        class: ""
      },
      {
        path: "/icons",
        title: "Orders",
        icon: "icon-cart",
        class: ""
      },
      {
        path: "/maps",
        title: "New Order",
        icon: "icon-bag-16",
        class: "" },
      {
        path: "/notifications",
        title: "Chat",
        icon: "icon-chat-33",
        class: ""
      },
    
      {
        path: "/user-profile",
        title: "Profile",
        icon: "icon-single-02",
        class: ""
      },
      {
        path: "/tables",
        title: "Logout",
        icon: "icon-lock-circle",
        class: ""
      }
    ];
  }
    this.menuItems = ROUTES.filter(menuItem => menuItem );

  }
  isMobileMenu() {
    if (window.innerWidth > 991) {
      return false;
    }
    return true;
  }
}
