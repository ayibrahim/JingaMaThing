import { Component, OnInit, Input } from "@angular/core";
import { Router } from '@angular/router';
import { Globals } from '../../Shared/globals'
import { ToastrService } from 'ngx-toastr';
import { HttpClient } from '@angular/common/http';
import { GalleriaThumbnails } from 'primeng';
export interface headers{}
export class customer{
  FirstName : string ; LastName : string; Email : string; Password: string; CustomerID : number; PhoneNumber : string; RoleDesc : string; Photo : string; SideBarColor : string; DashboardColor : string;
}
export class rmanager{
  FirstName : string ; LastName : string; Email : string; Password: string; ResourceManagerID : number; PhoneNumber : string; RoleDesc : string; Photo : string; SideBarColor : string; DashboardColor : string;
}
export class Dev{
  FirstName : string; LastName : string; Email : string; Password: string; DeveloperID : number; PhoneNumber : string;  RoleDesc : string; Description : string; PLanguages : string;
  Skills : string; Education : string; Certification : string; Title : string; Photo: string; SideBarColor : string; DashboardColor : string;
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
  public sidebarColor: string;
  testing : string;
  custfull : customer = new customer(); devfull : Dev = new Dev();
  rmfull : rmanager = new rmanager();
  iscustomer : boolean = false; isdeveloper: boolean = false; isrmanager : boolean = false;
  customerID : number;
  isuserporifle : boolean;
  istesting : boolean = true;
  newvar:any;
  historytype : string; newdata : any[]; isFirst : boolean = true;
  newuser : UserInfo = new UserInfo(); errormessage : string;
  constructor(private router: Router , public globals: Globals , private toastr: ToastrService , private http : HttpClient) {}
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
    if(this.isFirst == false)
    {
      this.http.get('https://localhost:44380/api/UpdateUserSideBarColor/' + this.newuser.ID + '/' + this.newuser.RoleDesc + '/' + color ).subscribe(
        (response2 : headers[]) => {
          this.newdata = response2;
          this.toastr.clear();
          this.errormessage = 'SideBarColor Updated Succesfully';
          this.showNotification('top', 'center' , this.errormessage);
          setTimeout(()=> this.toastr.clear() , 4000);
        }, (error) => {console.log('error message ' + error)}  
      )
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
    if(this.isFirst == false)
    {
    this.http.get('https://localhost:44380/api/UpdateUserDashboardColor/' + this.newuser.ID + '/' + this.newuser.RoleDesc + '/' + color ).subscribe(
      (response2 : headers[]) => {
        this.newdata = response2;
        this.toastr.clear();
        this.errormessage = 'DashboardColor Updated Succesfully';
        this.showNotification('top', 'center' , this.errormessage);
        setTimeout(()=> this.toastr.clear() , 4000);
      }, (error) => {console.log('error message ' + error)}  
    )
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
      this.custfull.SideBarColor = history.state.SideBarColor;
      this.custfull.DashboardColor = history.state.DashboardColor;
      this.iscustomer = true;
      this.changeDashboardColor(this.custfull.DashboardColor);
      this.changeSidebarColor(this.custfull.SideBarColor);
      this.isFirst = false;
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
      this.devfull.SideBarColor = history.state.SideBarColor;
      this.devfull.DashboardColor = history.state.DashboardColor;
      this.isdeveloper = true;
      this.changeDashboardColor(this.devfull.DashboardColor);
      this.changeSidebarColor(this.devfull.SideBarColor);
      this.isFirst = false;
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
      this.rmfull.SideBarColor = history.state.SideBarColor;
      this.rmfull.DashboardColor = history.state.DashboardColor;
      this.isrmanager = true;
      this.changeDashboardColor(this.rmfull.DashboardColor);
      this.changeSidebarColor(this.rmfull.SideBarColor);
      this.isFirst = false;
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
        this.router.navigate(['./home']);
      }
      if(this.historytype == 'resourcemanager')
      {
        this.router.navigate(['./home']);
      }
    }
    if(this.newvar == 'EmailComponent'){
      if(this.historytype == 'customer'){
      this.router.navigate(['./email'],{
        queryParams : {data : this.custfull.CustomerID , data2 : this.custfull.RoleDesc}
      })
      }
      if(this.historytype == 'resourcemanager'){
        this.router.navigate(['./email'],{
          queryParams : {data : this.rmfull.ResourceManagerID , data2 : this.rmfull.RoleDesc}
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
        this.router.navigate(['./home']);
      }
      if(this.historytype == 'resourcemanager')
      {
        this.router.navigate(['./home']);
      }
    }
    if(this.newvar == 'DevordersComponent'){
      if(this.historytype == 'customer'){
        this.router.navigate(['./home']);
      }
      if(this.historytype == 'resourcemanager')
      {
        this.router.navigate(['./home']);
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
        this.router.navigate(['./home']);
      }
      if(this.historytype == 'resourcemanager')
      {
        this.router.navigate(['./home']);
      }
    }
    if(this.newvar == 'LinksComponent'){
      if(this.historytype == 'customer'){
        this.router.navigate(['./home']);
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
        this.router.navigate(['./home']);
      }
      if(this.historytype == 'resourcemanager'){
        this.router.navigate(['./notes'],{
          queryParams : {data : this.rmfull.ResourceManagerID , data2 : this.rmfull.RoleDesc}
        })
        }
      if(this.historytype == 'developer'){
        this.router.navigate(['./notes'],{
          queryParams : {data : this.devfull.DeveloperID , data2 : this.devfull.RoleDesc}
        })
      }
    }
    if(this.newvar == 'RmdevelopersComponent'){
      if(this.historytype == 'customer'){
        this.router.navigate(['./home']);
      }
      if(this.historytype == 'resourcemanager'){
        this.router.navigate(['./rmdevelopers'],{
          queryParams : {data : this.rmfull.ResourceManagerID , data2 : this.rmfull.RoleDesc}
        })
        }
      if(this.historytype == 'developer'){
        this.router.navigate(['./home']);
      }
    }
    if(this.newvar == 'RmordersComponent'){
      if(this.historytype == 'customer'){
        this.router.navigate(['./home']);
      }
      if(this.historytype == 'resourcemanager'){
        this.router.navigate(['./rmorders'],{
          queryParams : {data : this.rmfull.ResourceManagerID , data2 : this.rmfull.RoleDesc}
        })
        }
      if(this.historytype == 'developer'){
        this.router.navigate(['./home']);
      }
    }
  }
  showNotification(from, align , message){

    const color = Math.floor((Math.random() * 5) + 1);

    switch(color){
      case 1:
      this.toastr.info('<span class="tim-icons icon-bell-55" [data-notify]="icon"></span> <b>'+message+'</b>.', '', {
         disableTimeOut: true,
         closeButton: true,
         enableHtml: true,
         toastClass: "alert alert-info alert-with-icon",
         positionClass: 'toast-' + from + '-' +  align
       });
      break;
      case 2:
      this.toastr.success('<span class="tim-icons icon-bell-55" [data-notify]="icon"></span> <b>'+message+'</b>.', '', {
         disableTimeOut: true,
         closeButton: true,
         enableHtml: true,
         toastClass: "alert alert-success alert-with-icon",
         positionClass: 'toast-' + from + '-' +  align
       });
      break;
      case 3:
      this.toastr.warning('<span class="tim-icons icon-bell-55" [data-notify]="icon"></span> <b>'+message+'</b>.', '', {
         disableTimeOut: true,
         closeButton: true,
         enableHtml: true,
         toastClass: "alert alert-warning alert-with-icon",
         positionClass: 'toast-' + from + '-' +  align
       });
      break;
      case 4:
      this.toastr.error('<span class="tim-icons icon-bell-55" [data-notify]="icon"></span> <b>'+message+'</b>.', '', {
         disableTimeOut: true,
         enableHtml: true,
         closeButton: true,
         toastClass: "alert alert-danger alert-with-icon",
         positionClass: 'toast-' + from + '-' +  align
       });
       break;
       case 5:
       this.toastr.show('<span class="tim-icons icon-bell-55" [data-notify]="icon"></span> <b>'+message+'</b>.', '', {
          disableTimeOut: true,
          closeButton: true,
          enableHtml: true,
          toastClass: "alert alert-primary alert-with-icon",
          positionClass: 'toast-' + from + '-' +  align
        });
      break;
      default:
      break;
    }
}
}
