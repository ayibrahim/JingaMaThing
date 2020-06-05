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
  RoleDesc : string;
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
    if(!history.state.type){
      this.router.navigate(['./home']);
    }
    if(history.state.type == 'customer'){
      this.RoleDesc = history.state.RoleDesc;
    }
    if(history.state.type == 'developer'){

      this.RoleDesc = history.state.RoleDesc;
      }

  }

}
