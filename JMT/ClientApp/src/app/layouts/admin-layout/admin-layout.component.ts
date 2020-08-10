import { Component, OnInit, Input } from "@angular/core";
import { Router } from '@angular/router';
import { Globals } from '../../Shared/globals'
import { ToastrService } from 'ngx-toastr';
export class customer{
  FirstName : string ; LastName : string; Email : string; Password: string; CustomerID : number; PhoneNumber : string; RoleDesc : string; Photo : string;
}
export class rmanager{
  FirstName : string ; LastName : string; Email : string; Password: string; ResourceManagerID : number; PhoneNumber : string; RoleDesc : string; Photo : string;
}
export class Dev{
  FirstName : string; LastName : string; Email : string; Password: string; DeveloperID : number; PhoneNumber : string;  RoleDesc : string; Description : string; PLanguages : string;
  Skills : string; Education : string; Certification : string; Title : string; Photo: string;
}
export class UserInfo {
  ID : number ; RoleDesc : string;
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
  rmfull : rmanager = new rmanager();
  iscustomer : boolean = false; isdeveloper: boolean = false; isrmanager : boolean = false;
  customerID : number;
  isuserporifle : boolean;
  istesting : boolean = true;
  newvar:any;
  historytype : string;
  newuser : UserInfo = new UserInfo();
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
      this.newuser.RoleDesc = history.state.RoleDesc;
      this.newuser.ID = history.state.CustomerID;
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
      this.newuser.RoleDesc = history.state.RoleDesc;
      this.newuser.ID = history.state.DeveloperID;
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
    if(history.state.type == 'resourcemanager'){
      this.newuser.RoleDesc = history.state.RoleDesc;
      this.newuser.ID = history.state.ResourceManagerID;
      this.historytype = history.state.type;
      this.rmfull.FirstName = history.state.FirstName;
      this.rmfull.LastName = history.state.LastName;
      this.rmfull.PhoneNumber = history.state.PhoneNumber;
      this.rmfull.Email = history.state.Email;
      this.rmfull.Password = history.state.Password;
      this.rmfull.ResourceManagerID = history.state.ResourceManagerID;
      this.rmfull.RoleDesc = history.state.RoleDesc;
      this.rmfull.Photo = history.state.Photo;
      this.isrmanager = true;
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
      if(this.historytype == 'resourcemanager'){
        this.router.navigate(['./user-profile'],{
          queryParams : {data : this.rmfull.ResourceManagerID , data2 : this.rmfull.RoleDesc}
        })
        }
      if(this.historytype == 'developer'){
        this.router.navigate(['./user-profile'],{
          queryParams : {data : this.devfull.DeveloperID , data2 : this.devfull.RoleDesc}
        })
      }
    }
    if(this.newvar == 'NewOrderComponent'){
      if(this.historytype == 'customer'){
      this.router.navigate(['./new-order'],{
        queryParams : {data : this.custfull.CustomerID , data2 : this.custfull.RoleDesc}
      })
      }
      if(this.historytype == 'developer'){
        this.router.navigate(['./new-order'],{
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
    if(this.newvar == 'CustomerordersComponent'){
      if(this.historytype == 'customer'){
      this.router.navigate(['./customerorders'],{
        queryParams : {data : this.custfull.CustomerID , data2 : this.custfull.RoleDesc}
      })
      }
      if(this.historytype == 'developer'){
        this.router.navigate(['./customerorders'],{
          queryParams : {data : this.devfull.DeveloperID , data2 : this.devfull.RoleDesc}
        })
      }
    }
    if(this.newvar == 'DevordersComponent'){
      if(this.historytype == 'customer'){
        
      this.router.navigate(['./devorders'],{
        queryParams : {data : this.custfull.CustomerID , data2 : this.custfull.RoleDesc}
      })
      }
      if(this.historytype == 'developer'){
        this.router.navigate(['./devorders'],{
          queryParams : {data : this.devfull.DeveloperID , data2 : this.devfull.RoleDesc}
        })
      }
    }
    if(this.newvar == 'CustomerDashboardComponent'){
      if(this.historytype == 'customer'){
      this.router.navigate(['./customerdashboard'],{
        queryParams : {data : this.custfull.CustomerID , data2 : this.custfull.RoleDesc}
      })
      }
      if(this.historytype == 'developer'){
        this.router.navigate(['./customerdashboard'],{
          queryParams : {data : this.devfull.DeveloperID , data2 : this.devfull.RoleDesc}
        })
      }
    }
    if(this.newvar == 'LinksComponent'){
      if(this.historytype == 'customer'){
      this.router.navigate(['./links'],{
        queryParams : {data : this.custfull.CustomerID , data2 : this.custfull.RoleDesc}
      })
      }
      if(this.historytype == 'resourcemanager'){
        this.router.navigate(['./links'],{
          queryParams : {data : this.rmfull.ResourceManagerID , data2 : this.rmfull.RoleDesc}
        })
        }
      if(this.historytype == 'developer'){
        this.router.navigate(['./links'],{
          queryParams : {data : this.devfull.DeveloperID , data2 : this.devfull.RoleDesc}
        })
      }
    }
    if(this.newvar == 'NotesComponent'){
      if(this.historytype == 'customer'){
      this.router.navigate(['./notes'],{
        queryParams : {data : this.custfull.CustomerID , data2 : this.custfull.RoleDesc}
      })
      }
      if(this.historytype == 'developer'){
        this.router.navigate(['./notes'],{
          queryParams : {data : this.devfull.DeveloperID , data2 : this.devfull.RoleDesc}
        })
      }
    }
  }
  
}
