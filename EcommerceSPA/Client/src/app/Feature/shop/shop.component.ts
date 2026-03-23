import { Component, inject } from '@angular/core';
import { ShopServiceService } from '../../Core/shop-service.service';
import { product } from '../../Shared/Models/product';
import {MatCard, MatCardModule} from '@angular/material/card';

@Component({
  selector: 'app-shop',
  imports: [
    MatCard
  ],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss',
})
export class ShopComponent {
 title = 'Skinet';
 private shopServices=inject(ShopServiceService)
  products:product[]=[];
 ngOnInit(): void {
   this.shopServices.getproducts() .subscribe(
{
  next:Response=>this.products=Response.data,
  error:err=>console.log(err),

}
    )
  }
}
