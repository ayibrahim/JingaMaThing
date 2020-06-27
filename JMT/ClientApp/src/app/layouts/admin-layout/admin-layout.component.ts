import { Component, OnInit, Input } from "@angular/core";
import { Router } from '@angular/router';
import { Globals } from '../../Shared/globals'
import { ToastrService } from 'ngx-toastr';
export class customer{
  FirstName : string ; LastName : string; Email : string; Password: string; CustomerID : number; PhoneNumber : string; RoleDesc : string; Photo : string;
}
export class Dev{
  FirstName : string; LastName : string; Email : string; Password: string; DeveloperID : number; PhoneNumber : string;  RoleDesc : string; Description : string; PLanguages : string;
  Skills : string; Education : string; Certification : string; Title : string; Photo: string;
}

@Component({
  selector: "app-admin-layout",
  templateUrl: "./admin-layout.component.html",
  styleUrls: [ "./admin-layout.component.css" ],
  providers: [ Globals ] 
})
export class AdminLayoutComponent implements OnInit {
  public sidebarColor: string = "red";
  testing : string;
  custfull : customer = new customer(); devfull : Dev = new Dev();
  iscustomer : boolean = false; isdeveloper: boolean = false;
  customerID : number;
  isuserporifle : boolean;
  istesting : boolean = true;
  newvar:any;
  historytype : string;
  constructor(private router: Router , public globals: Globals , private toastr: ToastrService) {}
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
      this.historytype = history.state.type;
      this.custfull.FirstName = history.state.FirstName;
      this.custfull.LastName = history.state.LastName;
      this.custfull.PhoneNumber = history.state.PhoneNumber;
      this.custfull.Email = history.state.Email;
      this.custfull.Password = history.state.Password;
      this.custfull.CustomerID = history.state.CustomerID;
      this.custfull.RoleDesc = history.state.RoleDesc;
      this.custfull.Photo = history.state.Photo;
      this.iscustomer = true;
    }
    if(history.state.type == 'developer'){
      this.historytype = history.state.type;
      this.devfull.FirstName = history.state.FirstName;
      this.devfull.LastName = history.state.LastName;
      this.devfull.PhoneNumber = history.state.PhoneNumber;
      this.devfull.Email = history.state.Email;
      this.devfull.Password = history.state.Password;
      this.devfull.DeveloperID = history.state.DeveloperID;
      this.devfull.Description = history.state.Description;
      this.devfull.PLanguages = history.state.PLanguages;
      this.devfull.Skills = history.state.Skills;
      this.devfull.Education = history.state.Education;
      this.devfull.Certification = history.state.Certification;
      this.devfull.Title = history.state.Title;
      this.devfull.RoleDesc = history.state.RoleDesc;
      this.devfull.Photo = history.state.Photo;
      this.isdeveloper = true;
      }
    
  }
  public onRouterOutletActivate(event : any) {
    console.log(event.__proto__.constructor.name);
     this.newvar = event.__proto__.constructor.name;
     this.toastr.clear();
     if(this.newvar == 'TablesComponent'){
      
      this.router.navigate(['./home']);
     }
    if(this.newvar == 'UserProfileComponent'){
      if(this.historytype == 'customer'){
      this.router.navigate(['./user-profile'],{
        queryParams : {data : this.custfull.CustomerID , data2 : this.custfull.RoleDesc}
      })
      }
      if(this.historytype == 'developer'){
        this.router.navigate(['./user-profile'],{
          queryParams : {data : this.devfull.DeveloperID , data2 : this.devfull.RoleDesc}
        })
      }
    }
    if(this.newvar == 'EmailComponent'){
      if(this.historytype == 'customer'){
      this.router.navigate(['./email'],{
        queryParams : {data : this.custfull.CustomerID , data2 : this.custfull.RoleDesc}
      })
      }
      if(this.historytype == 'developer'){
        this.router.navigate(['./email'],{
          queryParams : {data : this.devfull.DeveloperID , data2 : this.devfull.RoleDesc}
        })
      }
    }
  }
  
}
