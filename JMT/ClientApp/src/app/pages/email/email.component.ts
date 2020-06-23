import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpClient } from '@angular/common/http';
import { trigger, style, state, transition, animate } from '@angular/animations';
export interface headers{}
export interface customer{ 
  customerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; roleDesc : string; photo : string;
}
export interface Developer{
  developerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; description : string; pLanguages : string; skills : string; education : string; certification : string; title : string; roleDesc : string; photo : string;
}
export interface DevRMList{
  name : string; role : string; email : string;
}
@Component({
  selector: 'app-email',
  templateUrl: './email.component.html',
  styleUrls: ['./email.component.css'],
  animations: [
    trigger('rowExpansionTrigger', [
        state('void', style({
            transform: 'translateX(-10%)',
            opacity: 0
        })),
        state('active', style({
            transform: 'translateX(0)',
            opacity: 1
        })),
        transition('* <=> *', animate('400ms cubic-bezier(0.86, 0, 0.07, 1)'))
    ])
]
})
export class EmailComponent implements OnInit {
  //Menu Items
  items: MenuItem[]; MenuLabelChosen : any; errormessage : String; nodata: boolean = false;
  // Entering Component - Routing Params
  retrievedID : string; retrievedRole : string;customerId : string;developerId : string; selectedDevRM : DevRMList; NMTitle : string; NMDescription : string;
  developerlogin : Developer[]; loginresponse : customer[]; DevRMListbox : DevRMList[]; insertresponse : any;
  iscustomer : boolean  = false; isdeveloper : boolean = false; isMessages : boolean = true; isSentMessages : boolean = false; isNewMessage : boolean = false;
  CFirstName : string; CLastName : string; CEmail : string;  CustomerID : number; CPhoneNumber : string;  CPassword: string; CRoleDesc : string; CPhoto : any; CEmail2: string;
  DFirstName : string; DLastName : string; DEmail : string; DPassword: string; DeveloperID : number; DPhoneNumber : string; DPhoto : any; DEmail2 : string;
  DDescription: string; DPLanguages: string; DSkills: string; DEducation: string; DCertificates: string; DTitle: string; DRoleDesc : string;
  selecteddata1 : any;
  display1 : boolean = false; display2 : boolean = false; MSData : any[]; MSHeader : any[]; i : number; 
  
  constructor(private route: ActivatedRoute , private router : Router ,private http: HttpClient , private toastr: ToastrService) { }

  ngOnInit() {
    this.route.queryParams.subscribe((params=>{
      this.retrievedID = params.data;
      this.retrievedRole = params.data2;
      if(this.retrievedRole == 'Customer'){
        this.customerId = this.retrievedID;
      }
      if(this.retrievedRole == 'Developer'){
        this.developerId = this.retrievedID;
      }
    }))
    if(this.customerId != undefined){
      this.iscustomer = true;
      this.http.get('https://localhost:44380/api/getCustomerInfoByID/' + this.customerId)
      .subscribe(
          (response : customer[] ) => {
           this.loginresponse = response;
           this.CFirstName = this.loginresponse[0].firstName;
            this.CLastName = this.loginresponse[0].lastName;
            this.CEmail = this.loginresponse[0].email;
            this.CEmail2 = this.loginresponse[0].email;
            this.CPassword = this.loginresponse[0].password;
            this.CustomerID = this.loginresponse[0].customerID;
            this.CPhoneNumber = this.loginresponse[0].phoneNumber;
            this.CRoleDesc = this.loginresponse[0].roleDesc;
            this.CPhoto = this.loginresponse[0].photo;
            this.display2 = true;
            this.CInbox();
          }, (error) => {console.log('error message ' + error)}
          )
    }
    if(this.developerId != undefined){
      this.isdeveloper = true;
      this.http.get('https://localhost:44380/api/getDeveloperInfoByID/' + this.developerId)
            .subscribe(
                    (response2 : Developer[] ) => { 
                      this.developerlogin = response2;
                        this.DFirstName = this.developerlogin[0].firstName;
                        this.DLastName = this.developerlogin[0].lastName;
                        this.DEmail = this.developerlogin[0].email;
                        this.DEmail2 = this.developerlogin[0].email;
                        this.DPassword = this.developerlogin[0].password;
                        this.DeveloperID = this.developerlogin[0].developerID;
                        this.DPhoneNumber = this.developerlogin[0].phoneNumber;
                        this.DDescription = this.developerlogin[0].description;
                        this.DPLanguages = this.developerlogin[0].pLanguages;
                        this.DSkills = this.developerlogin[0].skills;
                        this.DEducation = this.developerlogin[0].education;
                        this.DCertificates = this.developerlogin[0].certification;
                        this.DTitle = this.developerlogin[0].title;
                        this.DRoleDesc = this.developerlogin[0].roleDesc;
                        this.DPhoto = this.developerlogin[0].photo;
                        this.display1 = true;
                        this.DInbox();
                    }, (error) => {console.log('error message ' + error)}
                    )
        
                    
                    
    }
    this.items = [
      {label: 'Messages', icon: 'pi pi-fw pi-inbox' , styleClass: "testingstyle"},
      {label: 'Sent Messages', icon: 'pi pi-fw pi-envelope'},
      {label: 'New Message', icon: 'pi pi-fw pi-pencil'}
  ];
  }
  test(event){
    this.MenuLabelChosen = event.toElement.parentNode.innerText;
    if(this.MenuLabelChosen == "Messages"){
      this.isSentMessages = false;
      this.isNewMessage = false;
      this.isMessages = true;
      if(this.retrievedRole == 'Customer'){
        this.CInbox();
      }
      if(this.retrievedRole == 'Developer'){
        this.DInbox();
      }
    }
    if(this.MenuLabelChosen == "Sent Messages"){
      this.isNewMessage = false;
      this.isMessages = false;
      this.display1 = false;
      this.display2 = false;
      this.nodata = false;
      this.isSentMessages = true;
    }
    if(this.MenuLabelChosen == "New Message"){
      this.isSentMessages = false;
      this.isMessages = false;
      this.display1 = false;
      this.display2 = false;
      this.nodata = false;
      this.isNewMessage = true;
      this.LoadDevRMList();
    }
  }
  
  DInbox(){
    this.http.get('https://localhost:44380/api/GetDeveloperInbox/' + this.DeveloperID).subscribe(
    (response : headers[]) => {
      this.MSData = response;
      if(this.MSData.length == 0){
        this.display1 = false;
        this.nodata = true;
        this.toastr.clear();
        this.errormessage = '*No Messges Found.';
        this.showNotification('top', 'center' , this.errormessage);
      } else {
        this.display1 = true;
        this.nodata = false;
      }
      this.MSHeader = [];
      for (this.i = 0; this.i < this.MSData.length; this.i++){
        for (var key in this.MSData[this.i]){
          if(this.MSHeader.indexOf(key) === -1){
            this.MSHeader.push(key);
          }
        }
      }   
    }, (error) => {console.log('Error Happened' + error)}, () => {console.log('the subscription is completed')}
    )
  }
  CInbox(){
    this.http.get('https://localhost:44380/api/GetCustomerInbox/' + this.CustomerID).subscribe(
    (response : headers[]) => {
      this.MSData = response;
      if(this.MSData.length == 0){
        this.display2 = false;
        this.nodata = true;
        this.toastr.clear();
        this.errormessage = '*No Messges Found.';
        this.showNotification('top', 'center' , this.errormessage);
      } else {
        this.display2 = true;
        this.nodata = false;
      }
      this.MSHeader = [];
      for (this.i = 0; this.i < this.MSData.length; this.i++){
        for (var key in this.MSData[this.i]){
          if(this.MSHeader.indexOf(key) === -1){
            this.MSHeader.push(key);
          }
        }
      }   
    }, (error) => {console.log('Error Happened' + error)}, () => {console.log('the subscription is completed')}
    )
  }
  LoadDevRMList(){
    this.http.get('https://localhost:44380/api/GetDevRMList').subscribe(
    (response : DevRMList[]) => {
      this.DevRMListbox = response;
      console.log(this.DevRMListbox);
      if(this.DevRMListbox.length == 0){
        this.toastr.clear();
        this.errormessage = '*No Developers or Resource Managers Exist';
        this.showNotification('top', 'center' , this.errormessage);
      }
    }, (error) => {console.log('Error Happened' + error)}, () => {console.log('the subscription is completed')}
    )
  }
  ListBoxClick(){
    if(this.selectedDevRM == null || this.selectedDevRM == undefined){
        this.toastr.clear();
        this.errormessage = '*No Send To Person Selected';
        this.showNotification('top', 'center' , this.errormessage);
        return;
    }
    if(!this.NMTitle){
        this.toastr.clear();
        this.errormessage = '*Please fill out Title';
        this.showNotification('top', 'center' , this.errormessage);
        return;
    }
    if(!this.NMDescription){
      this.toastr.clear();
      this.errormessage = '*Please fill out Description';
      this.showNotification('top', 'center' , this.errormessage);
      return;
  }

  //api/SendCustomerMessage/{RoleDesc}/{Email}/{Title}/{Description}/{EmailTo}
  this.http.get('https://localhost:44380/api/SendCustomerMessage/' + this.selectedDevRM.role + '/' + this.CEmail2 + '/' + this.NMTitle + '/' + this.NMDescription + '/'
  + this.selectedDevRM.email).subscribe(
    (response2 : headers[]) => {
      this.insertresponse = response2
      console.log(this.insertresponse);
    }, (error) => {console.log('error message ' + error)}
    
  )
  this.toastr.clear();
  this.errormessage = 'Message Sent';
  this.showNotification('top', 'center' , this.errormessage);
  this.NMDescription = undefined;
  this.NMTitle = undefined;
  this.selectedDevRM = undefined;
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
