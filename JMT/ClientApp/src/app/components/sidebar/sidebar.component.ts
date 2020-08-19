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
export class rmanager{
  FirstName : string ; LastName : string; Email : string; Password: string; ResourceManagerID : number; PhoneNumber : string; RoleDesc : string; Photo : string;
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
  @Input() rmfull : rmanager = new rmanager();
  iscustomer : boolean  = false;
  isdeveloper : boolean = false;
  isrmanager : boolean = false;
  constructor() {}
  
  ngOnInit() {
    if(this.custfull.FirstName != undefined){
      this.iscustomer = true;
    }
    if(this.devfull.FirstName != undefined){
      this.isdeveloper = true;
    }
    if(this.rmfull.FirstName != undefined){
      this.isrmanager = true;
    }
    if(this.isrmanager == true)
    {
      ROUTES = [
        {
          path: "/rmorders",
          title: "Orders",
          icon: "icon-cart",
          class: ""
        },
        {
          path: "/rmdevelopers",
          title: "Developers",
          icon: "icon-badge",
          class: ""
        },
        {
          path: "/email",
          title: "Messages",
          icon: "icon-chat-33",
          class: ""
        },
        {
          path: "/notes",
          title: "Notes",
          icon: "icon-notes",
          class: "" },
          {
            path: "/links",
            title: "Links",
            icon: "icon-world",
            class: "" },
        {
          path: "/user-profile",
          title: "Profile",
          icon: "icon-single-02",
          class: ""
        },
        {
          path: "/home",
          title: "Logout",
          icon: "icon-lock-circle",
          class: ""
        }
      ];
    }
    if(this.isdeveloper == true){
      ROUTES = [
        
        {
          path: "/devorders",
          title: "Orders",
          icon: "icon-cart",
          class: ""
        },
        {
          path: "/email",
          title: "Messages",
          icon: "icon-chat-33",
          class: ""
        },
        {
          path: "/notes",
          title: "Notes",
          icon: "icon-notes",
          class: "" },
          {
            path: "/links",
            title: "Links",
            icon: "icon-world",
            class: "" },
        {
          path: "/user-profile",
          title: "Profile",
          icon: "icon-single-02",
          class: ""
        },
        {
          path: "/home",
          title: "Logout",
          icon: "icon-lock-circle",
          class: ""
        }
      ];
  }
  if(this.iscustomer == true){
    ROUTES = [
      {
        path: "/customerdashboard",
        title: "Dashboard",
        icon: "icon-chart-pie-36",
        class: ""
      },
      {
        path: "/customerorders",
        title: "Orders",
        icon: "icon-cart",
        class: ""
      },
      {
        path: "/new-order",
        title: "New Order",
        icon: "icon-bag-16",
        class: "" },
      {
        path: "/email",
        title: "Messages",
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
        path: "/home",
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
