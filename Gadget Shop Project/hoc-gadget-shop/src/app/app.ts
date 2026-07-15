import { Component, signal } from '@angular/core';
import { RouterOutlet, RouterModule } from '@angular/router';
import { Inventory } from './appComponents/inventory/inventory';
import { Customer } from './appComponents/customer/customer';
// import { Inventory } from './appComponents/inventory/inventory';
// import : {InventoryComponent} from './appComponents/inventory.Inventory'


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, RouterModule, Inventory, Customer],
  standalone:true,
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('hoc-gadget-shop');
}
