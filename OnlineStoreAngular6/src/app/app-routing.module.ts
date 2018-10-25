import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ActorComponent } from "./actor/actor.component";
import { CustomerComponent } from "./customer/customer.component";
import { CategoryComponent } from "./category/category.component";
import { SampleComponent } from "./sample/sample.component";
import { EmployeeComponent } from "./employee/employee.component";
import { ShipperComponent } from "./shipper/shipper.component";
import { SupplierComponent } from "./supplier/supplier.component";
import { ShowComponent } from './show/show.component';
import { AirportComponent } from './airport/airport.component';
import { ProductComponent } from './product/product.component';
import { OrderComponent } from './order/order.component';
import { PersonComponent } from './person/person.component';
import { NameComponent } from './name/name.component';
import { QualificationComponent } from './qualification/qualification.component';


const routes: Routes = [
  { path: '', redirectTo: '/actor', pathMatch: 'full' },
  { path: 'actor', component: ActorComponent },
  { path: 'category', component: CategoryComponent },
  { path: 'customer', component: CustomerComponent },
  { path: 'show', component: ShowComponent },
  { path: 'airport', component: AirportComponent },
  { path: 'employee', component: EmployeeComponent },
  { path: 'shipper', component: ShipperComponent },
  { path: 'supplier', component: SupplierComponent },
  { path: 'product', component: ProductComponent },
  { path: 'order', component: OrderComponent },
  { path: 'person', component: PersonComponent },
  { path: 'name', component: NameComponent },
  { path: 'qualification', component: QualificationComponent },
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
