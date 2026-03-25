import { Component, inject } from '@angular/core';
import { ShopServiceService } from '../../Core/shop-service.service';
import { product } from '../../Shared/Models/product';
import {MatCard} from '@angular/material/card';
import { ProductItemComponent } from "./product-item/product-item.component";
import{MatDialog} from '@angular/material/dialog';
import { FiltersDialogComponent } from './filters-dialog/filters-dialog.component';
import { MatAnchor } from "@angular/material/button";
import { MatIcon } from "@angular/material/icon";

@Component({
  selector: 'app-shop',
  imports: [
    
    ProductItemComponent,
    MatAnchor,
    MatIcon
],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss',
})
export class ShopComponent {
 title = 'Skinet';
 private shopServices=inject(ShopServiceService)
 private dialogServices=inject(MatDialog)
  products:product[]=[];
 ngOnInit(): void {
 this.initilazeShop();
  }

  initilazeShop(){
    this.shopServices.getbrands();
    this.shopServices.gettypes();

      this.shopServices.getproducts() .subscribe(
{
  next:Response=>this.products=Response.data,
  error:err=>console.log(err),

}
    )
  }
  OpenFiltersDialog(){
    const dialogRef=this.dialogServices.open(FiltersDialogComponent,{
      minWidth:'500px',
    })
  }
}
