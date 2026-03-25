import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { pagination } from '../Shared/Models/pagination';
import { product } from '../Shared/Models/product';

@Injectable({
  providedIn: 'root',
})
export class ShopServiceService {
   private baseUrl='http://localhost:5268/api/'
    private http=inject(HttpClient);
    brands:string[]=[];
    types:string[]=[];
    getproducts(){
   return   this.http.get<pagination<product>>(this.baseUrl + 'product?pageSize=20');
    }

    getbrands(){
      return this.http.get<string[]>(this.baseUrl +'product/brands').subscribe({
        next:response=>this.brands=response
      })
    }
    gettypes(){
      return this.http.get<string[]>(this.baseUrl +'product/types').subscribe({
        next:Response=>this.types=Response
      })
    }
}
