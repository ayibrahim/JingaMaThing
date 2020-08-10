import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { SelectItem } from 'primeng';
export interface headers{}
export interface customer{ 
  customerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; roleDesc : string; photo : string;
}
export interface Developer{
  developerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; description : string; pLanguages : string; skills : string; education : string; certification : string; title : string; roleDesc : string; photo : string;
}
export interface LinkTable {
  developerLinkID : number;  title : string; hyperLink : string; viewType : string; 
}
export interface UpdateLink {
  DeveloperLinkID : string; Title : string; HyperLink : string; ViewType : string;
}
export interface CreateLink {
  DeveloperID : string; LinkTitle : string; LinkURL : string; LinkType : string;
}
interface CreateLinks extends Array<CreateLink>{}
interface UpdateLinks extends Array<UpdateLink>{}
@Component({
  selector: 'app-links',
  templateUrl: './links.component.html',
  styleUrls: ['./links.component.css']
})
export class LinksComponent implements OnInit {
  retrievedID : string; retrievedRole : string;customerId : string;developerId : string; errormessage : String;  newdata : headers[];
  iscustomer : boolean  = false; isdeveloper : boolean = false;
  CFirstName : string; CLastName : string; CEmail : string;  CustomerID : number; CPhoneNumber : string;  CPassword: string; CRoleDesc : string; CPhoto : any; CEmail2: string;
  DFirstName : string; DLastName : string; DEmail : string; DPassword: string; DeveloperID : number; DPhoneNumber : string; DPhoto : any; DEmail2 : string;
  DDescription: string; DPLanguages: string; DSkills: string; DEducation: string; DCertificates: string; DTitle: string; DRoleDesc : string;
  developerlogin : Developer[]; loginresponse : customer[]; nodevlinks : boolean = true;
  SelectedLinkID : any; deletedialog : boolean = false; DevLinksHeader : any[]; DevLinksData : any[]; i : any;
  LinkURL : any; LinkTitle : any; LinksTypes: SelectItem[];  LinkType: any;
  nopubliclinks : boolean = true; selecteddata1 : any; selecteddata2 : any; PLHeader : any[]; PLData : any[];
  constructor(private route: ActivatedRoute , private router : Router ,private http: HttpClient , private toastr: ToastrService) { }

  ngOnInit() 
  {
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
                        this.GetDevLinks();
                        this.GetPublicLinks();
                    }, (error) => {console.log('error message ' + error)}
                    )
                          
    }
    this.LinksTypes = [
      {label:'Public', value: 'Public'},
      {label:'Private', value: 'Private'}
    ]

  }
  GetDevLinks()
  {
    this.http.get('https://localhost:44380/api/GetDeveloperLinks/' + this.DeveloperID).subscribe(
    (response : LinkTable[]) => {
      this.DevLinksData = response;
      console.log(this.DevLinksData);
      if(this.DevLinksData.length == 0){
        this.nodevlinks = true;
        this.toastr.clear();
        this.errormessage = '*No Links Found.';
        setTimeout(()=> this.toastr.clear(),3000);
        this.showNotification('top', 'center' , this.errormessage);
      } else {
        this.nodevlinks = false;
      }
      this.DevLinksHeader = [];
      for (this.i = 0; this.i < this.DevLinksData.length; this.i++){
        for (var key in this.DevLinksData[this.i]){
          if(this.DevLinksHeader.indexOf(key) === -1){
            if(key == 'developerLinkID'){

            }else {
              this.DevLinksHeader.push(key);
            }
          }
        }
      }   
    }, (error) => {this.nodevlinks = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Links Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=> this.toastr.clear(),3000);
      console.log('error message ' + error)}
    )
   
  }
  GetPublicLinks()
  {
    this.http.get('https://localhost:44380/api/GetPublicLinksDev/' + this.DeveloperID).subscribe(
    (response : headers[]) => {
      this.PLData = response;
      console.log(this.PLData);
      if(this.PLData.length == 0){
        this.nopubliclinks = true;
        this.toastr.clear();
        this.errormessage = '*No Public Links Found.';
        setTimeout(()=> this.toastr.clear(),3000);
        this.showNotification('top', 'center' , this.errormessage);
      } else {
        this.nopubliclinks = false;
      }
      this.PLHeader = [];
      for (this.i = 0; this.i < this.PLData.length; this.i++){
        for (var key in this.PLData[this.i]){
          if(this.PLHeader.indexOf(key) === -1){
            if(key == 'linkID'){

            }else {
              this.PLHeader.push(key);
            }
          }
        }
      }   
    }, (error) => {this.nopubliclinks = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Public Links Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=> this.toastr.clear(),3000);
      console.log('error message ' + error)}
    )
  }
  CreateNewlink()
  {
    if(!this.LinkTitle){
      this.toastr.clear();
      this.errormessage = '*Link title is required';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=> this.toastr.clear() , 3000);
      return;
    }
    if(!this.LinkType){
      this.toastr.clear();
      this.errormessage = '*Link Display Type is required';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=> this.toastr.clear() , 3000);
      return;
    }
    if(!this.LinkURL){
      this.toastr.clear();
      this.errormessage = '*Link URL is required';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=> this.toastr.clear() , 3000);
      return;
    }
    if(!this.LinkURL.includes("http")){
      this.toastr.clear();
      this.errormessage = '*Link URL must be in correct url format';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=> this.toastr.clear() , 3000);
      return;
    }
    var result2 : CreateLinks = [
      {  DeveloperID : this.DeveloperID.toString() , LinkTitle : this.LinkTitle.toString() , LinkURL : this.LinkURL.toString() , LinkType : this.LinkType.toString() }
      ];
      const httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
      }
    this.http.post('https://localhost:44380/api/CreateDevLink' , result2[0] , httpOptions).subscribe(
      (response : headers[]) => {
        this.newdata = response;
        console.log(this.newdata);
        this.toastr.clear();
        this.errormessage = 'Link Created Successfully';
        this.showNotification('top', 'center' , this.errormessage);
        setTimeout(()=> this.toastr.clear() , 3000);
      }, (error) => {this.toastr.clear();
        this.errormessage = 'Error Happened When Creating Link , Refresh and Try Again!';
        this.showNotification('top', 'center' , this.errormessage);
        setTimeout(()=> this.toastr.clear() , 3000);
        console.log('error message ' + error)}
      )
    this.LinkTitle = undefined; this.LinkType = undefined; this.LinkURL = undefined;
    setTimeout(()=> this.GetDevLinks() , 2000);
  }
  CloseDeleteDialog(){this.deletedialog = false;}
  onRowEditInit(task: LinkTable) {
    
  }
  onRowEditSave(task: LinkTable) {
    var result2 : UpdateLinks = [
      {  DeveloperLinkID : task.developerLinkID.toString() , Title : task.title.toString() , HyperLink : task.hyperLink.toString() , ViewType : task.viewType.toString() }
      ];
      const httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
      }    
     this.http.post('https://localhost:44380/api/UpdateDevLink' , result2[0] , httpOptions).subscribe(data => {
      this.toastr.clear();
      this.errormessage = 'Link Updated Succesfully';
      this.showNotification('top', 'center' , this.errormessage);
        }, error => {
          this.toastr.clear();
          this.errormessage = 'Error Happened When Updating Link , Refresh and Try Again!';
          this.showNotification('top', 'center' , this.errormessage);
          setTimeout(()=>  this.toastr.clear() , 2000);
          console.log('error message ' + error)
     });
     setTimeout(()=> this.GetDevLinks() , 2000);
     setTimeout(()=>  this.toastr.clear() , 2000);
  }
  DeleteLink()
  {
    this.http.get('https://localhost:44380/api/DeleteDevLink/' + this.SelectedLinkID) .subscribe(
      (response2 : headers[]) => {
        this.newdata = response2;
        this.toastr.clear();
        this.errormessage = 'Link Deleted Succesfully';
       this.showNotification('top', 'center' , this.errormessage);
      }, (error) => {this.toastr.clear();
       this.errormessage = 'Error Happened When Deleting Link , Refresh and Try Again!';
       this.showNotification('top', 'center' , this.errormessage);
       console.log('error message ' + error)}
     )
    this.deletedialog = false;
    this.SelectedLinkID = undefined;
    setTimeout(()=> this.GetDevLinks() , 2000);
    setTimeout(()=> this.toastr.clear() , 4000);
  }
  onRowEditCancel(task: LinkTable, index: number) {
    console.log(task);
    this.deletedialog = true;
    this.SelectedLinkID = task.developerLinkID
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
