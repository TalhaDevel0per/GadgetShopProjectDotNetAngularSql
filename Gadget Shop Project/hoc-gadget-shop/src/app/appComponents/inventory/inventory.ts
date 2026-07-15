import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { provideHttpClient } from '@angular/common/http';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
// import { DialogBox } from '../../appComponent/dialog-box/dialog-box';
import { DialogBoxComponent } from '../../appComponent/dialog-box/dialog-box';



@Component({
  selector: 'app-inventory',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './inventory.html',
  styleUrls: ['./inventory.css'],

})



export class Inventory implements OnInit {
  constructor(private httpClient: HttpClient) { }

  private modalService = inject(NgbModal)
  productIdToDelete: number = 0;



  inventoryData = {
    productId: 0,
    productName: '',
    availableQty: 0,
    reOrderPoint: 0

  }

  disabledProductIdInput = false;

  inventoryDetails: any;

  ngOnInit() {
    this.getInventoryDetails();
  }

  getInventoryDetails() {
    let apiUrl = "https://localhost:7129/api/Inventory/GetInventoryData";
    // let apiUrl="http://localhost:4200/inventory";

    this.httpClient.get(apiUrl).subscribe(data => {
      this.inventoryDetails = data;

      console.log(this.inventoryDetails)

    });

    this.disabledProductIdInput= false;

  }

  // onSubmit(): void {
  //   debugger;
  //   // let apiUrl = "https://localhost:7129/api/Inventory";
  //   let apiUrl = this.disabledProductIdInput
  // ? "https://localhost:7129/api/Inventory/UpdateInventoryData"
  // : "https://localhost:7129/api/Inventory";

  onSubmit(): void {
    let apiUrl = this.disabledProductIdInput
      ? "https://localhost:7129/api/Inventory/UpdateInventoryData"
      : "https://localhost:7129/api/Inventory";

    this.httpClient[this.disabledProductIdInput ? 'put' : 'post'](apiUrl, this.inventoryData)
      .subscribe({
        next: () => {
          alert("Success");

          this.getInventoryDetails(); // 🔥 refresh table

          // 🔥 reset form
          this.inventoryData = {
            productId: 0,
            productName: '',
            availableQty: 0,
            reOrderPoint: 0
          };

          this.disabledProductIdInput = false;
        },
        error: (e) => console.log(e)
      });


    let httpOptions = {
      headers: new HttpHeaders({
        authorization: 'my-auth-token ',
        'Content-Type': "application/json"
      })
    }

    if (this.disabledProductIdInput == true) {
      this.httpClient.put(apiUrl, this.inventoryData, httpOptions).subscribe({
        next: v => console.log(v),
        error: e => console.log(e),
        complete: () => {
          alert("Form Submitted Successfully: " + JSON.stringify(this.inventoryData));
          this.getInventoryDetails();

        }
      });


    }
    else {

      this.httpClient.post(apiUrl, this.inventoryData, httpOptions).subscribe({
        next: v => console.log(v),
        error: e => console.log(e),
        complete: () => {
          alert("Form Submitted Successfully: " + JSON.stringify(this.inventoryData));
          this.getInventoryDetails();

        }
      });


    }
  }

  openConfirmDialog(productId: number) {
    this.productIdToDelete = productId;
    console.log(this.productIdToDelete);
    this.modalService.open(DialogBoxComponent).result.then((data) => {
      if (data.event == "confirm") {
        this.deleteInventory()
        //   console.log("Confirmed To Delete");
        // }
        // else{
        //       console.log("Delete Not Required")

        // }
      }
    });
  }
  deleteInventory(): void {
    let apiUrl = 'https://localhost:7129/api/Inventory/DeleteInventoryData?productId=' + this.productIdToDelete;
    console.log(apiUrl)

    this.httpClient.delete(apiUrl).subscribe(data => {
      this.getInventoryDetails();


    });
  }

  populateFormForEdit(inventory: any) {
    this.inventoryData.productId = inventory.productId;
    this.inventoryData.productName = inventory.productName;
    this.inventoryData.availableQty = inventory.availableQty;
    this.inventoryData.reOrderPoint = inventory.reOrderPoint;

    this.disabledProductIdInput = true

  }



}
