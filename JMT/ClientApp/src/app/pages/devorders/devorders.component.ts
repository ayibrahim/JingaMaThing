import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { MenuItem, SelectItem } from 'primeng';
import {OverlayPanel} from 'primeng/overlaypanel';
import { formatDate } from '@angular/common';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';
export interface headers{}
export interface customer{ 
  customerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; roleDesc : string; photo : string;
}
export interface Developer{
  developerID : number; email : string; firstName : string; lastName : string; password : string; phoneNumber : string; description : string; pLanguages : string; skills : string; education : string; certification : string; title : string; roleDesc : string; photo : string;
}
export interface DevList{
  name : string; role : string; email : string;
}
export interface DevPendingOrders {
  developerProjectID : number; customerID : number ; developerID : number; orderDesc : string ; dateRequested : string ; Budget : string ; Requirements : string ; Name : string;
}
export interface NewTask{
  OrderID : string; DeveloperID : string; Description : string; Title : string; Notes : string;
}
export interface TaskTable {
  developerTaskID : number; orderNumber : number; title : string; description : string; notes : string; status : string;
}
export interface UpdateTask {
  DeveloperTaskID : string; Title : string; Description : string; Status : string; Notes : string;
}
interface UpdateTasks extends Array<UpdateTask>{}
interface NewTasks extends Array<NewTask>{}
@Component({
  selector: 'app-devorders',
  templateUrl: './devorders.component.html',
  styleUrls: ['./devorders.component.css']
})

export class DevordersComponent implements OnInit {
  isOpenOrder : boolean = true; isPendingOrder : boolean = false; isOrderHistory : boolean = false;
  retrievedID : string; retrievedRole : string;customerId : string;developerId : string; errormessage : String;  newdata : headers[];
  iscustomer : boolean  = false; isdeveloper : boolean = false;
  CFirstName : string; CLastName : string; CEmail : string;  CustomerID : number; CPhoneNumber : string;  CPassword: string; CRoleDesc : string; CPhoto : any; CEmail2: string;
  DFirstName : string; DLastName : string; DEmail : string; DPassword: string; DeveloperID : number; DPhoneNumber : string; DPhoto : any; DEmail2 : string;
  DDescription: string; DPLanguages: string; DSkills: string; DEducation: string; DCertificates: string; DTitle: string; DRoleDesc : string;
  developerlogin : Developer[]; loginresponse : customer[];
  items: MenuItem[]; MenuLabelChosen : any; displayBasic: boolean;  displayEditDialog: boolean ; displaydecline : boolean ;
  nopendingdata1 : boolean = true; DevPendingList : DevPendingOrders[]; dialogrequirment : string; OCompleteDate : string; ONewPrice : number = 0.00; expanddialog: boolean = false;
  ODeclineReason : any; DeclineID : any; ONewID : any; currentdate : string; DevOpenOrders : any[]; DevOpenHeaders : any[]; i : number; noopenorders : boolean = true; selecteddata1 : any;
  notasks : boolean = true; TasksHeaders : any[]; TasksData : TaskTable[]; selecteddata2 : any; OrderSelectedLoadTask : boolean = false;
  OrderIDSelected : any; newtaskdialog : boolean = false;
  NTTitle : string; NTDescription : string; NTNotes : string; disabled: boolean = true; editing : boolean = false;
  Statuses: SelectItem[]; deletedialog : boolean = false; TaskDeleteID : number; TaskDeletOrderID : number;
  custpendingdata : boolean = false; CustApprovPendingHeader : any[]; CustApprovPendingData : any[]; selecteddata3 : any;
  noorderhistory : boolean = true; DevOrderHistoryHeaders : any[]; DevOrderHistory : any[];devhistoryselected : any; 
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
    if(this.retrievedRole == undefined){
      if(history.state.type == 'customer'){
        this.customerId = history.state.CustomerID;
      }
      if(history.state.type == 'developer'){
        this.developerId = history.state.DeveloperID;
      }
    }
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
                        this.GetDevOpenOrders();
                        this.GetDevOrders();
                        this.GetDevPendingCustomerOrders();
                        this.GetCustomerHistoryOrders();
                    }, (error) => {console.log('error message ' + error)}
                    )
       
    }
    this.items = [
      {label: 'Open Orders', icon: 'pi pi-fw pi-th-large' , styleClass: "testingstyle"},
      {label: 'Pending Orders', icon: 'pi pi-fw pi-eye'},
      {label: 'Order History', icon: 'pi pi-fw pi-search'}
    ];
    this.Statuses = [
      {label: 'In Progress', value: 'In Progress'},
      {label: 'Complete', value: 'Complete'}
    ]
  this.currentdate = formatDate(new Date(), 'yyyy-MM-dd', 'en_US');
  }
  DeclineOrder(){
    if(!this.ODeclineReason){
      this.toastr.clear();
      this.errormessage = '*Decline Reason Required';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=> this.toastr.clear(), 4000);
      return;
    }
    this.http.get('https://localhost:44380/api/UpdateDevOrder/' + this.DeclineID + '/' + this.ODeclineReason) .subscribe(
       (response2 : headers[]) => {
         this.newdata = response2;
         this.toastr.clear();
         this.errormessage = 'Declined Succesfully';
        this.showNotification('top', 'center' , this.errormessage);
       }, (error) => {this.toastr.clear();
        this.errormessage = 'Error Happened When Declining Order , Refresh and Try Again!';
        this.showNotification('top', 'center' , this.errormessage);
        console.log('error message ' + error)}
      )
    this.displaydecline = false;
    this.GetDevOrders();
    this.DeclineID = undefined ; this.DeclineID = null;
    this.ODeclineReason = undefined ; this.ODeclineReason = null;
    setTimeout(()=>{  
      this.toastr.clear();
    }, 4000);
      
  }
  GetDevPendingCustomerOrders(){
    this.http.get('https://localhost:44380/api/GetDevPendingCustomerOrders/' + this.DeveloperID).subscribe(
    (response : headers[]) => {
      this.CustApprovPendingData = response;
      if (this.CustApprovPendingData.length == 0){
        this.custpendingdata = true;
      } else {
        this.custpendingdata = false;
      }
      this.CustApprovPendingHeader = [];
      for (this.i = 0; this.i < this.CustApprovPendingData.length; this.i++){
        for (var key in this.CustApprovPendingData[this.i]){
          if(this.CustApprovPendingHeader.indexOf(key) === -1){
            if(key == 'requirements' || key == 'customerPendingID'){

            }else {
              this.CustApprovPendingHeader.push(key);
            }
            
          }
        }
      }   
    }, (error) => {this.custpendingdata = true;this.toastr.clear();
      this.errormessage = 'Error Happened When Loading Pending Orders Try Again or Contact Support';
      this.showNotification('top', 'center' , this.errormessage);
      console.log('error message ' + error)}
    )
   
  }
  GetCustomerHistoryOrders()
  {
    this.http.get('https://localhost:44380/api/GetDevOrderHistory/' + this.DeveloperID).subscribe(
    (response : headers[]) => {
      this.DevOrderHistory = response;
      console.log(this.DevOrderHistory);
      if(this.DevOrderHistory.length == 0){
        this.noorderhistory = true;
        this.toastr.clear();
        this.errormessage = '*No Previous Orders Found.';
        this.showNotification('top', 'center' , this.errormessage);
      } else {
        this.noorderhistory = false;
      }
      this.DevOrderHistoryHeaders = [];
      for (this.i = 0; this.i < this.DevOrderHistory.length; this.i++){
        for (var key in this.DevOrderHistory[this.i]){
          if(this.DevOrderHistoryHeaders.indexOf(key) === -1){
            if(key == 'requirements'){

            }else {
              this.DevOrderHistoryHeaders.push(key);
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
  MarkAsComplete(order){
    this.http.get('https://localhost:44380/api/UpdateDevOrder/' + order.orderNumber) .subscribe(
      (response2 : headers[]) => {
        this.newdata = response2;
        this.toastr.clear();
        this.errormessage = 'Order Updated to Completed Succesfully';
       this.showNotification('top', 'center' , this.errormessage);
      }, (error) => {this.toastr.clear();
       this.errormessage = 'Error Happened When Completing Order , Refresh and Try Again!';
       this.showNotification('top', 'center' , this.errormessage);
       console.log('error message ' + error)}
     )
    setTimeout(()=>{  
      this.GetDevOpenOrders(); 
    }, 1000);
    setTimeout(()=>{  
      this.toastr.clear();
    }, 3000);
    this.OrderSelectedLoadTask = false;
  }
  onRowEditInit(task: TaskTable) {
    
  }
  onRowEditSave(task: TaskTable) {
    this.TaskDeletOrderID = task.orderNumber;
    var result2 : UpdateTasks = [
      {  DeveloperTaskID : task.developerTaskID.toString() , Title : task.title.toString() , Description : task.description.toString() , Status : task.status.toString() , Notes : task.notes.toString() }
      ];
      const httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
      }    
     this.http.post('https://localhost:44380/api/UpdateTask' , result2[0] , httpOptions).subscribe(data => {
      this.toastr.clear();
      this.errormessage = 'Task Updated Succesfully';
      this.showNotification('top', 'center' , this.errormessage);
        }, error => {
          this.toastr.clear();
          this.errormessage = 'Error Happened When Updating Task , Refresh and Try Again!';
          this.showNotification('top', 'center' , this.errormessage);
          setTimeout(()=>  this.toastr.clear() , 2000);
          console.log('error message ' + error)
     });
     setTimeout(()=> this.GetOrderTasks(this.TaskDeletOrderID) , 2000);
     setTimeout(()=>  this.toastr.clear() , 2000);
  }
  onRowEditCancel(task: TaskTable, index: number) {
    this.deletedialog = true;
    this.TaskDeletOrderID = task.orderNumber;
    this.TaskDeleteID = task.developerTaskID;
  }
  ConfirmDeleteTask(){
    this.http.get('https://localhost:44380/api/DeleteTask/' + this.TaskDeleteID ) .subscribe(
       (response2 : headers[]) => {
         this.newdata = response2;
         this.toastr.clear();
         this.errormessage = 'Task Deleted Succesfully';
        this.showNotification('top', 'center' , this.errormessage);
        this.displayEditDialog = false;
       }, (error) => {this.toastr.clear();
        this.errormessage = 'Error Happened When Deleting Task , Refresh and Try Again!';
        this.showNotification('top', 'center' , this.errormessage);
        setTimeout(()=>  this.toastr.clear() , 2000);
        console.log('error message ' + error)}
      )
    this.deletedialog = false;
    this.TaskDeleteID = undefined;
    setTimeout(()=> this.GetOrderTasks(this.TaskDeletOrderID) , 2000);
    setTimeout(()=>  this.toastr.clear() , 2000);
  }
  CloseDeletTaskDialog(){
    this.deletedialog = false;
    this.TaskDeleteID = undefined;
  }
  DeclineDialogShow(ID : any){
    this.toastr.clear();  
    this.displayBasic = false;
    this.displayEditDialog = false;
    this.displaydecline = true;
    this.DeclineID = ID;
  }
  showBasicDialog(requirmentval) {
    this.toastr.clear();
    this.dialogrequirment = requirmentval;
    this.displayEditDialog = false;
    this.displayBasic = true;
  }
  onDate(ed){
    this.OCompleteDate = this.convert(this.OCompleteDate);
  }
 convert(str){
   var date = new Date(str),
   mnth = ("0" + (date.getMonth() + 1)).slice(-2),
   day = ("0" + date.getDate()).slice(-2);
   return [date.getFullYear(),mnth , day].join("-");
 }
 AcceptOrder(){
  if(!this.ONewPrice || !this.OCompleteDate){
    this.toastr.clear();
    this.errormessage = '*Fill Out Both Fields Before Accepting';
    this.showNotification('top', 'center' , this.errormessage);
    setTimeout(()=> this.toastr.clear(), 4000);
    return;
  }
  let date2 = formatDate(this.OCompleteDate , 'yyyy-MM-dd' , 'en_US');
    if(this.currentdate >= date2){
      this.toastr.clear();
      this.errormessage = '*Complete Date must be greater than ' + this.currentdate;
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=>{    //<<<---    using ()=> syntax
        this.toastr.clear();
        }, 4000);
      return;
    } 
  this.toastr.clear();
  this.http.get('https://localhost:44380/api/AcceptDevOrder/' + this.ONewID + '/' + this.ONewPrice + '/' + this.OCompleteDate) .subscribe(
       (response2 : headers[]) => {
         this.newdata = response2;
         this.toastr.clear();
         this.errormessage = 'Accepted Succesfully';
        this.showNotification('top', 'center' , this.errormessage);
        this.GetDevOrders();
        this.displayEditDialog = false;
       }, (error) => {this.toastr.clear();
        this.errormessage = 'Error Happened When Accepting Order , Refresh and Try Again!';
        this.showNotification('top', 'center' , this.errormessage);
        console.log('error message ' + error)}
      )
      this.displayEditDialog = false;
  setTimeout(()=> this.GetDevPendingCustomerOrders(),2000) ;
 }
 ShowEditDialog(ID : any){
   this.displayBasic = false;
   this.displayEditDialog = true;
   this.ONewPrice = undefined ; this.ONewPrice = null;
   this.OCompleteDate = undefined ; this.OCompleteDate = null;
   this.ONewID = ID;
 }
  menuswitch(event){
    this.MenuLabelChosen = event.toElement.parentNode.innerText;
    this.toastr.clear();
    if(this.MenuLabelChosen == "Open Orders"){
      this.isOrderHistory = false;
      this.isPendingOrder = false;
      this.isOpenOrder = true;
      this.GetDevOpenOrders();
    }
    if(this.MenuLabelChosen == "Pending Orders"){
      this.isOrderHistory = false;
      this.isOpenOrder = false;
      this.isPendingOrder = true;
      this.GetDevOrders();
      this.GetDevPendingCustomerOrders();
    }
    if(this.MenuLabelChosen == "Order History"){
      this.isPendingOrder = false;
      this.isOpenOrder = false;
      this.isOrderHistory = true;
      this.GetCustomerHistoryOrders();
    }
  }
  GetDevOpenOrders()
  {
    this.http.get('https://localhost:44380/api/GetDevOpenOrders/' + this.DeveloperID).subscribe(
    (response : headers[]) => {
      this.DevOpenOrders = response;
      console.log(this.DevOpenOrders);
      if(this.DevOpenOrders.length == 0){
        this.noopenorders = true;
        this.toastr.clear();
        this.errormessage = '*No Open Orders Found.';
        this.showNotification('top', 'center' , this.errormessage);
      } else {
        this.noopenorders = false;
      }
      this.DevOpenHeaders = [];
      for (this.i = 0; this.i < this.DevOpenOrders.length; this.i++){
        for (var key in this.DevOpenOrders[this.i]){
          if(this.DevOpenHeaders.indexOf(key) === -1){
            if(key == 'developerID' || key == 'requirements'){

            }else {
              this.DevOpenHeaders.push(key);
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
            if(key == 'developerTaskID'){

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
  ShowNewTaskDialog(){
    this.NTTitle = undefined; this.NTDescription = undefined; this.NTNotes = undefined;
    this.NTTitle = null; this.NTDescription = null; this.NTNotes = null;
    this.newtaskdialog = true;
  }
  CreateNewTask()
  { 
    if(!this.NTTitle|| !this.NTDescription|| !this.NTNotes){
      this.toastr.clear();
      this.errormessage = '*Please Fill Out All Fields for new Task';
      this.showNotification('top', 'center' , this.errormessage);
      setTimeout(()=> this.toastr.clear(),3000);
      return;
     }
    
    var result: NewTasks = [
      {  OrderID : this.OrderIDSelected.toString() , DeveloperID : this.DeveloperID.toString() , Description : this.NTDescription.toString() , Title : this.NTTitle.toString() , Notes : this.NTNotes.toString()  }
      ];
      const httpOptions = {
        headers: new HttpHeaders({'Content-Type': 'application/json'})
      }    
     this.http.post('https://localhost:44380/api/InsertNewTask' , result[0] , httpOptions).subscribe(data => {
         console.log(data)
        }, error => {
       console.log(error)
     });
     this.HideNewTaskDialog();
     setTimeout(()=>  this.GetOrderTasks(this.OrderIDSelected) , 1000);
    ;
  }
  HideNewTaskDialog(){
    
    this.newtaskdialog = false;
  }
  OnOrderOpenSelect(event){
    this.OrderSelectedLoadTask = true;
    this.OrderIDSelected = event.data.orderNumber;
    this.GetOrderTasks(this.OrderIDSelected);
  }
  GetDevOrders(){
    this.http.get('https://localhost:44380/api/GetDevPendingOrders/' + this.DeveloperID)
    .subscribe(
        (response : DevPendingOrders[] ) => {
         this.DevPendingList = response;
         console.log(this.DevPendingList);
         if (this.DevPendingList.length == 0){
          this.nopendingdata1 = true;
          this.toastr.clear();
          this.errormessage = 'You have no orders to accept or decline';
          this.showNotification('top', 'center' , this.errormessage);
          setTimeout(()=> this.toastr.clear(),3000);
        } else {
          this.nopendingdata1 = false;
        }
        }, (error) => {console.log('error message ' + error)}
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
