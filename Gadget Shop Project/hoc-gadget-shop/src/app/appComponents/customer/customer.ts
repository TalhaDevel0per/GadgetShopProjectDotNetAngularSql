import { Component, inject } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CommonModule } from '@angular/common';
import { CustomerDialogBox } from '../customer-dialog-box/customer-dialog-box';
import { HttpClient } from '@angular/common/http';
import { DialogBoxComponent } from '../../appComponent/dialog-box/dialog-box';

@Component({
  selector: 'app-customer',
  imports: [CommonModule],
  templateUrl: './customer.html',
  styleUrl: './customer.css',
  standalone:true
})
export class Customer {

  private modalService = inject(NgbModal)

  httpClient = inject(HttpClient)
  customerDetails:any;

   openCustomerDialog(){
    this.modalService.open(CustomerDialogBox).result.then(data=>{
      if(data.event=="closed"){
        this.getCustomerDetails();
      }
    })

   }

   ngOnInit(){
    this.getCustomerDetails();

   }
   getCustomerDetails(){
    let apiUrl="https://localhost:7129/api/Customer/GetCustomerData";
    this.httpClient.get(apiUrl).subscribe(result=>{
      this.customerDetails=result;
      console.log(this.customerDetails)
    })

   }

   openConfirmDialog(customerId: any){
    this.modalService.open(DialogBoxComponent).result.then((data) => {
      console.log(data);
      if (data.event == "confirm") {
        this.deleteCustomerDetails(customerId); 
        
      }
    });
   }
   deleteCustomerDetails(customerId: any){
    let apiUrl="https://localhost:7129/api/Customer/DeleteCustomerData?customerId=";
    this.httpClient.delete(apiUrl+customerId).subscribe(data=>{
      this.getCustomerDetails()
    });

   }
   openEditDialogBox(customer:any){
    const modalRefrence = this.modalService.open(CustomerDialogBox);
    modalRefrence.componentInstance.customer = {
      customerId: customer.customerId,
      firstName: customer.firstName,
      lastName: customer.lastName,
      email: customer.email,
      registrationDate: customer.registrationDate,
      phone: customer.phone
    }
   

   modalRefrence.result.then(data=>{
     if(data.event=="close"){
        this.getCustomerDetails();
      }
   })

   
  }
}
