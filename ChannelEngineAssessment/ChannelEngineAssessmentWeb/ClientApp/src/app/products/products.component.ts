import { Component, OnInit } from '@angular/core';
import { ProductsService } from './services/products.service';
import { TopSoldProductModel } from './models/top-sold-product.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  public topSoldProducts : TopSoldProductModel[];

  public constructor(private _productsService: ProductsService, private _router: Router) { }

  public ngOnInit(): void {
    this.getProducts();
  }

  public getProducts(): void {
    this._productsService.getTopSoldProducts().subscribe(x => this.topSoldProducts = x.items);
  }

  public openProductDetails(merchantProductNo: string): void {
    this._router.navigate(['/products', merchantProductNo, 'details']);
  }
}
