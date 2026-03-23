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
    getproducts(){
   return   this.http.get<pagination<product>>(this.baseUrl + 'product');
    }
}
