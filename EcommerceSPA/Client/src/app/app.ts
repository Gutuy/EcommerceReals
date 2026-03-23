import { Component, inject, OnInit } from '@angular/core';
import { HeaderComponent } from "./Layout/header/header.component";
import { HttpClient } from '@angular/common/http';
import { product } from './Shared/Models/product';
import { pagination } from './Shared/Models/pagination';
import { ShopServiceService } from './Core/shop-service.service';
import { ShopComponent } from "./Feature/shop/shop.component";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    HeaderComponent,
    ShopComponent
],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent {
 
 title="skinet"

}