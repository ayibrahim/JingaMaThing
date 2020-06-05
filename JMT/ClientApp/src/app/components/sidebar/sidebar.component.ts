import { Component, OnInit, Input } from "@angular/core";

declare interface RouteInfo {
  path: string;
  title: string;

  icon: string;
  class: string;
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
  @Input() RoleDesc : string;
  constructor() {}
  
  ngOnInit() {
    console.log(this.RoleDesc);
    if(this.RoleDesc == 'Developer'){
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
          path: "/user",
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
  if(this.RoleDesc == 'Customer'){
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
        path: "/user",
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
    this.menuItems = ROUTES.filter(menuItem => menuItem);
    

  }
  isMobileMenu() {
    if (window.innerWidth > 991) {
      return false;
    }
    return true;
  }
}
