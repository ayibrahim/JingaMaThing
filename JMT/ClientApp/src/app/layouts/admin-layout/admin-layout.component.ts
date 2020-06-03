import { Component, OnInit, Input } from "@angular/core";
import { Router } from '@angular/router';
import { Globals } from '../../Shared/globals'
@Component({
  selector: "app-admin-layout",
  templateUrl: "./admin-layout.component.html",
  styleUrls: [ "./admin-layout.component.css" ],
  providers: [ Globals ] 
})
export class AdminLayoutComponent implements OnInit {
  public sidebarColor: string = "red";
  constructor(private router: Router , public globals: Globals) {}
  changeSidebarColor(color){
    var sidebar = document.getElementsByClassName('sidebar')[0];
    var mainPanel = document.getElementsByClassName('main-panel')[0];

    this.sidebarColor = color;

    if(sidebar != undefined){
        sidebar.setAttribute('data',color);
    }
    if(mainPanel != undefined){
        mainPanel.setAttribute('data',color);
    }
  }
  changeDashboardColor(color){
    var body = document.getElementsByTagName('body')[0];
    if (body && color === 'white-content') {
        body.classList.add(color);
    }
    else if(body.classList.contains('white-content')) {
      body.classList.remove('white-content');
    }
  }
  ngOnInit() {
    if(history.state.type === true){
    console.log(history.state.FirstName);
    console.log(history.state.LastName);
    console.log(history.state.PhoneNumber);
    console.log(history.state.Email);
    console.log(history.state.Password);
    console.log(history.state.CustomerID);
    console.log(history.state.RoleDesc);
    }
    if(history.state.type === false){
      console.log(history.state.FirstName);
      console.log(history.state.LastName);
      console.log(history.state.PhoneNumber);
      console.log(history.state.Email);
      console.log(history.state.Password);
      console.log(history.state.Description);
      console.log(history.state.PLanguages);
      console.log(history.state.Skills);
      console.log(history.state.Education);
      console.log(history.state.Certification);
      console.log(history.state.Title);
      console.log(history.state.DeveloperID);
      console.log(history.state.RoleDesc);
      }
  }

}
