import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { MenuItem } from 'primeng';
import { trigger, style, state, transition, animate } from '@angular/animations';
import { Dev } from 'src/app/layouts/admin-layout/admin-layout.component';
export interface headers{}
export interface customer{ 
  customerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; roleDesc : string; photo : string;
}
export interface Developer{
  developerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; description : string; pLanguages : string; skills : string; education : string; certification : string; title : string; roleDesc : string; photo : string;
}

export interface CustomerPendingApproval{
  customerPendingID : number;customerID : number;developerID : number;priceOffered : string;dateOffered : string;requirements : string;orderDesc : string;name : string;
}
export interface TaskTable {
  developerTaskID : number; orderNumber : number; title : string; description : string; notes : string; status : string;
}
export interface OrderComplete {
  OrderID : string; Review : string; Rating : string; 
}
interface OrderCompleted extends Array<OrderComplete>{}
@Component({
  selector: 'app-customerorders',
  templateUrl: './customerorders.component.html',
  styleUrls: ['./customerorders.component.css']
})

export class CustomerordersComponent implements OnInit {
  retrievedID : string; retrievedRole : string;customerId : string;developerId : string; errormessage : String;  newdata : headers[];
  iscustomer : boolean  = false; isdeveloper : boolean = false;
  CFirstName : string; CLastName : string; CEmail : string;  CustomerID : number; CPhoneNumber : string;  CPassword: string; CRoleDesc : string; CPhoto : any; CEmail2: string;
  DFirstName : string; DLastName : string; DEmail : string; DPassword: string; DeveloperID : number; DPhoneNumber : string; DPhoto : any; DEmail2 : string;
  DDescription: string; DPLanguages: string; DSkills: string; DEducation: string; DCertificates: string; DTitle: string; DRoleDesc : string;
  developerlogin : Developer[]; loginresponse : customer[];
  items: MenuItem[]; MenuLabelChosen : any;  CustomerPendingResponse : any[]; i : number; CustomerPendingHeader: any[]; dialogrequirment : string;
  CPDData : any[]; CPDHeader : any[];  nopendingdata2 : boolean = true; CustomerPendingList : CustomerPendingApproval[];  displayBasic : boolean = false;
  isOpenOrder : boolean = true ; isPendingOrder : boolean = false; isOrderHistory : boolean = false; nopendingdata1 : boolean = true; nopendingdatadeclined : boolean = true;
  noopenorders : boolean = true; selecteddata1 : any;  CustomerOpenHeaders : any[]; CustomerOpenOrder : any[];
  OrderSelectedLoadTask : boolean = false; notasks : boolean = true; TasksHeaders : any[]; TasksData : any[];  selecteddata2 : any; OrderIDSelected : any;
  orderdevelopedrequirement : any; displaycustopenorderdeveloped : boolean = false; noopendevpending : boolean = true; CustOpenOrdersDeveloped : any[];
  noorderhistory : boolean = true; cotselecteddata : any; CustomerOrderHistoryHeaders : any[]; CustomerOrderHistory : any[]; disabled : boolean = true;
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
            this.GetCPendingOrders();
            this.GetCPendingDeclined();
            this.GetCustomerOrders();
            this.GetCustomerOpenOrders();
            this.GetCustomerDevelopedOrders();
            this.GetCustomerHistoryOrders();
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
                    }, (error) => {console.log('error message ' + error)}
                    )
       
    }
    this.items = [
      {label: 'Open Orders', icon: 'pi pi-fw pi-th-large' , styleClass: "testingstyle"},
      {label: 'Pending Orders', icon: 'pi pi-fw pi-eye'},
      {label: 'Order History', icon: 'pi pi-fw pi-search'}
  ];
  }
  OnOrderOpenSelect(event){
    this.OrderSelectedLoadTask = true;
    this.OrderIDSelected = event.data.orderNumber;
    this.GetOrderTasks(this.OrderIDSelected);
  }
  menuswitch(event){
    this.MenuLabelChosen = event.toElement.parentNode.innerText;
    this.toastr.clear();
    if(this.MenuLabelChosen == "Open Orders"){
      this.isOrderHistory = false;
      this.isPendingOrder = false;
      this.isOpenOrder = true;
      this.GetCustomerOpenOrders();
      this.GetCustomerDevelopedOrders();
    }
    if(this.MenuLabelChosen == "Pending Orders"){
      this.isOrderHistory = false;
      this.isOpenOrder = false;
      this.isPendingOrder = true;
      this.GetCPendingOrders();
      this.GetCPendingDeclined();
      this.GetCustomerOrders();
    }
    if(this.MenuLabelChosen == "Order History"){
      this.isPendingOrder = false;
      this.isOpenOrder = false;
      this.isOrderHistory = true;
      this.GetCustomerHistoryOrders();
    }
  }
  CustomerMarkDevelopedOrder(review : string , rating : string , ID : string)
  {
    if(!rating|| !review){
      this.toastr.clear();
      this.errormessage = '*Please fill out review and rating before completing order';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=> this.toastr.clear() , 3000);
      return;
    }
    var result: OrderCompleted = [
      { OrderID : ID.toString() , Review : review.toString() , Rating : rating.toString()  }
      ];
      const httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
      }    
     this.http.post('https://localhost:44380/api/UpdateOrderComplete' , result[0] , httpOptions).subscribe(data => {
         console.log(data)
         this.toastr.clear();
         this.errormessage = 'Submited Successfully';
         this.showNotification('top', 'center' , this.errormessage);
        }, error => {
       console.log(error)
     });
     setTimeout(()=> this.GetCustomerDevelopedOrders() , 2000);
     setTimeout(()=> this.toastr.clear() , 3000);
  }
  GetCustomerOpenOrders()
  {
    this.http.get('https://localhost:44380/api/GetCustomerOpenOrders/' + this.CustomerID).subscribe(
    (response : headers[]) => {
      this.CustomerOpenOrder = response;
      console.log(this.CustomerOpenOrder);
      if(this.CustomerOpenOrder.length == 0){
        this.noopenorders = true;
        this.toastr.clear();
        this.errormessage = '*No Open Orders Found.';
        this.showNotification('top', 'center' , this.errormessage);
      } else {
        this.noopenorders = false;
      }
      this.CustomerOpenHeaders = [];
      for (this.i = 0; this.i < this.CustomerOpenOrder.length; this.i++){
        for (var key in this.CustomerOpenOrder[this.i]){
          if(this.CustomerOpenHeaders.indexOf(key) === -1){
            if(key == 'customerID' || key == 'requirements'){

            }else {
              this.CustomerOpenHeaders.push(key);
            }
          }
        }
      }   
    }, (error) => {this.noopenorders = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Open Orders Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      console.log('error message ' + error)}
    )
   
  }
  GetCustomerHistoryOrders()
  {
    this.http.get('https://localhost:44380/api/GetCustomerOrderHistory/' + this.CustomerID).subscribe(
    (response : headers[]) => {
      this.CustomerOrderHistory = response;
      console.log(this.CustomerOrderHistory);
      if(this.CustomerOrderHistory.length == 0){
        this.noorderhistory = true;
        this.toastr.clear();
        this.errormessage = '*No Previous Orders Found.';
        this.showNotification('top', 'center' , this.errormessage);
      } else {
        this.noorderhistory = false;
      }
      this.CustomerOrderHistoryHeaders = [];
      for (this.i = 0; this.i < this.CustomerOrderHistory.length; this.i++){
        for (var key in this.CustomerOrderHistory[this.i]){
          if(this.CustomerOrderHistoryHeaders.indexOf(key) === -1){
            if(key == 'requirements'){

            }else {
              this.CustomerOrderHistoryHeaders.push(key);
            }
          }
        }
      }   
    }, (error) => {this.noorderhistory = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Previous Orders Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      console.log('error message ' + error)}
    )
   
  }
  showcustorderdevelopeddialog(requirement : any){
    this.toastr.clear();
    this.orderdevelopedrequirement = requirement;
    this.displaycustopenorderdeveloped = true;
  }
  GetOrderTasks(ID : any)
  {
    this.http.get('https://localhost:44380/api/GetOrderTasks/' + ID).subscribe(
    (response : TaskTable[]) => {
      this.TasksData = response;
      console.log(this.TasksData);
      if(this.TasksData.length == 0){
        this.notasks = true;
        this.toastr.clear();
        this.errormessage = '*No Tasks Found.';
        setTimeout(()=> this.toastr.clear(),3000);
        this.showNotification('top', 'center' , this.errormessage);
      } else {
        this.notasks = false;
      }
      this.TasksHeaders = [];
      for (this.i = 0; this.i < this.TasksData.length; this.i++){
        for (var key in this.TasksData[this.i]){
          if(this.TasksHeaders.indexOf(key) === -1){
            if(key == 'developerTaskID' || key =='notes'){

            }else {
              this.TasksHeaders.push(key);
            }
          }
        }
      }   
    }, (error) => {this.notasks = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Tasks for Order Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=> this.toastr.clear(),3000);
      console.log('error message ' + error)}
    )
   
  }
  showBasicDialog(requirmentval) {
    this.toastr.clear();
    this.dialogrequirment = requirmentval;
    this.displayBasic = true;
  }
  DeclineCustomerOrder(ID : any){
    this.http.get('https://localhost:44380/api/UpdateCustomerDeclined/' + ID ) .subscribe(
       (response2 : headers[]) => {
         this.newdata = response2;
         this.toastr.clear();
         this.errormessage = 'Declined Succesfully';
        this.showNotification('top', 'center' , this.errormessage);
       }, (error) => {this.toastr.clear();
        this.errormessage = 'Error Happened When Declined Order , Refresh and Try Again!';
        this.showNotification('top', 'center' , this.errormessage);
        console.log('error message ' + error)}
      )
    this.GetCustomerOrders();
  }
  AcceptCustomerOrder(ID : any , CustomerID : any , DeveloperID : any , Price : any, CompletionDate : any , OrderDesc : any , Requirements : any){
    this.http.get('https://localhost:44380/api/InsertNewOrderDevCustomerApproved/' + ID + '/' + CustomerID + '/' + DeveloperID + '/' + Price + '/' + CompletionDate
    + '/' + OrderDesc + '/' + Requirements ) .subscribe(
      (response2 : headers[]) => {
        this.newdata = response2;
        this.toastr.clear();
        this.errormessage = 'Accepted Succesfully';
        this.showNotification('top', 'center' , this.errormessage);
        this.GetCustomerOrders();
      }, (error) => {this.toastr.clear();
       this.errormessage = 'Error Happened When Accepting Order , Refresh and Try Again!';
       this.showNotification('top', 'center' , this.errormessage);
       console.log('error message ' + error)}
     )
    
  }
  GetCustomerOrders(){
    this.http.get('https://localhost:44380/api/GetCustomerPendingApproval/' + this.CustomerID)
    .subscribe(
        (response : CustomerPendingApproval[] ) => {
         this.CustomerPendingList = response;
         console.log(this.CustomerPendingList);
         if (this.CustomerPendingList.length == 0){
          this.nopendingdata2 = true;
        } else {
          this.nopendingdata2 = false;
        }
        }, (error) => {console.log('error message ' + error)}
        )
  }
  GetCustomerDevelopedOrders(){
    this.http.get('https://localhost:44380/api/GetCustomerDevelopedOrders/' + this.CustomerID)
    .subscribe(
        (response : headers[] ) => {
         this.CustOpenOrdersDeveloped = response;
         console.log(this.CustOpenOrdersDeveloped);
         if (this.CustOpenOrdersDeveloped.length == 0){
          this.noopendevpending = true;
        } else {
          this.noopendevpending = false;
        }
        }, (error) => {console.log('error message ' + error)}
        )
  }
  GetCPendingOrders(){
    this.http.get('https://localhost:44380/api/GetCustomerPendingOrders/' + this.CustomerID).subscribe(
    (response : headers[]) => {
      this.CustomerPendingResponse = response;
      if (this.CustomerPendingResponse.length == 0){
        this.nopendingdata1 = true;
      } else {
        this.nopendingdata1 = false;
      }
      this.CustomerPendingHeader = [];
      for (this.i = 0; this.i < this.CustomerPendingResponse.length; this.i++){
        for (var key in this.CustomerPendingResponse[this.i]){
          if(this.CustomerPendingHeader.indexOf(key) === -1){
            if(key == 'requirements' || key == 'developerPendingID'){

            }else {
              this.CustomerPendingHeader.push(key);
            }
            
          }
        }
      }   
    }, (error) => {this.nopendingdata1 = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Pending Orders Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      console.log('error message ' + error)}
    )
   
  }

  GetCPendingDeclined(){
    this.http.get('https://localhost:44380/api/GetCustomerPendingDeclined/' + this.CustomerID).subscribe(
    (response : headers[]) => {
      this.CPDData = response;
      if (this.CPDData.length == 0){
        this.nopendingdatadeclined = true;
      } else {
        this.nopendingdatadeclined = false;
      }
      this.CPDHeader = [];
      for (this.i = 0; this.i < this.CPDData.length; this.i++){
        for (var key in this.CPDData[this.i]){
          if(this.CPDHeader.indexOf(key) === -1){
            if(key == 'developerDeclinedID'){

            }else {
              this.CPDHeader.push(key);
            }
            
          }
        }
      }   
    }, (error) => {this.nopendingdata1 = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Declined Orders Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      console.log('error message ' + error)}
    )
   
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
