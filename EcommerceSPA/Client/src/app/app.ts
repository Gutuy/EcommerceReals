import { Component } from '@angular/core';
import { HeaderComponent } from "./Layout/header/header.component";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    HeaderComponent
],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class AppComponent {
  title = 'Skinet';
}