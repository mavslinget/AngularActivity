import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  menuItem: MenuItem[];
  

  ngOnInit(): void {
    this.menuItem = [
      { label: "Actor", icon: "fa fa-user", routerLink: ['/actor']},
      { label: "Category", icon: "fa fa-calendar", routerLink: ['/category']},
      { label: "Customer", icon: "fa fa-user", routerLink: ['/customer']},
      { label: "Airport", icon: "fa fa-users", routerLink: ['/airport']},
      { label: "Show", icon: "fa fa-users", routerLink: ['/show']},
      { label: "Employee", icon: "fa fa-user", routerLink: ['/employee']},
      { label: "Shipper", icon: "fa fa-users", routerLink: ['/shipper']},
      { label: "Supplier", icon: "fa fa-users", routerLink: ['/supplier']},
      { label: "Product", icon: "fa fa-calendar", routerLink: ['/product']},
      { label: "Order", icon: "fa fa-calendar", routerLink: ['/order']},
      { label: "Person", icon: "fa fa-user", routerLink: ['/person']},
      { label: "Name", icon: "fa fa-user", routerLink: ['/name']},
      { label: "Qualification", icon: "fa fa-calendar", routerLink: ['/qualification']}
    ]
  }
}
