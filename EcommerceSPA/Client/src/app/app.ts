import { Component, inject, OnInit } from '@angular/core';
import { HeaderComponent } from "./Layout/header/header.component";
import { HttpClient } from '@angular/common/http';
import { product } from './Shared/Models/product';
import { pagination } from './Shared/Models/pagination';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    HeaderComponent
],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent implements OnInit{
 
  title = 'Skinet';
  private baseUrl='http://localhost:5268/api/'
  private http=inject(HttpClient);
  products:product[]=[];
 ngOnInit(): void {
    this.http.get<pagination<product>>(this.baseUrl + 'product').subscribe(
{
  next:Response=>this.products=Response.data,
  error:err=>console.log(err),
  complete:()=>console.log("complete"),
}
    )
  }

}