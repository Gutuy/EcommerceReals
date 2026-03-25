import { Component, inject } from '@angular/core';

import { ShopServiceService } from '../../../Core/shop-service.service';
import{MatDivider} from '@angular/material/divider'
import{MatList, MatListOption, MatSelectionList} from '@angular/material/list'
import { MatAnchor } from "@angular/material/button";
@Component({
  selector: 'app-filters-dialog',
  imports: [MatDivider,
    MatSelectionList,
    MatListOption, MatAnchor],
  templateUrl: './filters-dialog.component.html',
  styleUrl: './filters-dialog.component.scss',
})
export class FiltersDialogComponent {
shopServices=inject(ShopServiceService);
}
