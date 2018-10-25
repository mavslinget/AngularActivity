import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SampleComponent } from './sample/sample.component';
import { FormsModule } from '@angular/forms'
import { ReactiveFormsModule } from '@angular/forms'
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { DialogModule } from 'primeng/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CalendarModule } from 'primeng/calendar';
import {
  MatInputModule, MatPaginatorModule, MatProgressSpinnerModule,
  MatSortModule, MatTableModule
} from "@angular/material";

import { ButtonModule } from 'primeng/button';
import { CategoryComponent } from './category/category.component';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { DataTableModule } from 'primeng/primeng';
import { MenuModule } from 'primeng/menu';
import { RadioButtonModule } from 'primeng/radiobutton';
import { DropdownModule } from 'primeng/dropdown';


import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { CustomerComponent } from './customer/customer.component';
import { EmployeeComponent } from './employee/employee.component';
import { ShipperComponent } from './shipper/shipper.component';
import { SupplierComponent } from './supplier/supplier.component';
import { ActorComponent } from './actor/actor.component';
import { ShowComponent } from './show/show.component';
import { AirportComponent } from './airport/airport.component';
import { ProductComponent } from './product/product.component';
import { OrderComponent } from './order/order.component';
import { NgxMaskModule } from 'ngx-mask';
import { ImageUploadModule } from "angular2-image-upload";
import { FileSelectDirective } from 'ng2-file-upload';



import {
  MatAutocompleteModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatExpansionModule,
  MatFormFieldModule,
  MatGridListModule,
  MatIconModule,
  MatListModule,
  MatMenuModule,
  MatProgressBarModule,
  MatRadioModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
  MatStepperModule,
  MatNativeDateModule
} from '@angular/material';
import { OrderDetailComponent } from './order/order-detail/order-detail.component';
import { PersonComponent } from './person/person.component';
import { NameComponent } from './name/name.component';
import { QualificationComponent } from './qualification/qualification.component';


@NgModule({
  declarations: [
    AppComponent,
    SampleComponent,
    CategoryComponent,
    CustomerComponent,
    EmployeeComponent,
    ShipperComponent,
    SupplierComponent,
    ActorComponent,
    ShowComponent,
    AirportComponent,
    ProductComponent,
    OrderComponent,
    OrderDetailComponent,
    PersonComponent,
    FileSelectDirective,
    NameComponent,
    QualificationComponent
  ],
  imports: [
    BrowserModule,
    ButtonModule,
    DataTableModule,
    HttpModule,
    HttpClientModule,
    TableModule,
    FormsModule,
    ReactiveFormsModule,
    InputTextModule,
    InputTextareaModule,
    DialogModule,
    BrowserAnimationsModule,
    CalendarModule,
    MenuModule,
    CommonModule,
    RadioButtonModule,
    MatInputModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatSortModule,
    MatTableModule,
    DropdownModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatDatepickerModule,
    MatDialogModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatGridListModule,
    MatIconModule,
    MatListModule,
    MatMenuModule,
    MatProgressBarModule,
    MatRadioModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatStepperModule,
    MatNativeDateModule,
    AppRoutingModule,
    NgxMaskModule.forRoot(),
    ImageUploadModule.forRoot()
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
