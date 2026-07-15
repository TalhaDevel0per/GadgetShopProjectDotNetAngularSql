import { Routes } from '@angular/router';
// import { InventoryComponent } from './appComponents/inventory/inventoryComponent';
// import { InventoryComponet } from './appComponents/inventory/Inventory.Component';
import { Inventory } from './appComponents/inventory/inventory';
import { Customer } from './appComponents/customer/customer';


export const routes: Routes = [{path:'inventory', component:Inventory},
    {path:'customer', component : Customer}
];
