import { CommonModule } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, inject, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-customer-dialog-box',
  standalone:true,
  imports: [FormsModule, CommonModule],
  templateUrl: './customer-dialog-box.html',
  styleUrls:['./customer-dialog-box.css']
})
export class CustomerDialogBox {

  @Input() private customer :any;
  btnText:string ="Add";
  disableCustomerIdInput= false;



  httpClient=inject(HttpClient)

  modal =   inject(NgbActiveModal)
  customerDetails={
    customerId:"",
    firstName:"",
    lastName:"",
    registrationDate:new Date(),
    phone:"",
    email:"",
  }


  onSubmit(){
    let apiUrl="https://localhost:7129/api/Customer/UpdateInventoryData";

    let httpOptions={
      headers:new HttpHeaders({
        Authorization: 'my-auth-token',
        'content-type':'application/json'
      })
    }
if(this.disableCustomerIdInput==true){
  this.httpClient.put(apiUrl, this.customerDetails, httpOptions).subscribe(
      {
        next:v=>console.log(v),
        error:e=>console.log(e),
        complete:()=>{
          alert("Customer Details Update Successfully:"+JSON.stringify(this.customerDetails))
          this.modal.close({event:"close"})
        }
      }
    )

}
else{
    this.httpClient.post(apiUrl, this.customerDetails, httpOptions).subscribe(
      {
        next:v=>console.log(v),
        error:e=>console.log(e),
        complete:()=>{
          alert("Customer Details Saved Successfully:"+JSON.stringify(this.customerDetails))
          this.modal.close({event:"close"})
        }
      }
    )
    }
  }

  ngOnInit(){
    if(this.customer!=null){
      this.customerDetails  = this.customer;
      this.btnText="Update";
      this.disableCustomerIdInput=true;
    }

    
  }
}
