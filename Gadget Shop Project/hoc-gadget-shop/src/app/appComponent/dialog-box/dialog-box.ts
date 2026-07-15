  import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
  import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';


  @Component({
    selector: 'app-dialog-box',
    imports: [CommonModule],
    standalone: true,
    templateUrl: './dialog-box.html',
    styleUrls: ['./dialog-box.css'],
    
  })
  export class DialogBoxComponent {

    modal = inject(NgbActiveModal)

 
    
    confirm(){
      this.modal.close({event:'confirm'}); 

    }
    
    cencel(){
      this.modal.dismiss()
    }
  }
