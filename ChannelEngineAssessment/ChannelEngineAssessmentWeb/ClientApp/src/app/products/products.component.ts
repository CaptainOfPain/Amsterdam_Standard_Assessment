import { Component, OnInit } from '@angular/core';
import { ProductsService } from './services/products.service';
import { TopSoldProductModel } from './models/top-sold-product.model';
import { Router } from '@angular/router';
import { SaveProductRequestModel } from './models/save-product-request.model';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  public topSoldProducts : TopSoldProductModel[];
  public isNewProductViewVisible: boolean = false;

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

  public createProduct(request: SaveProductRequestModel): void {
    this._productsService.createProduct(request).subscribe(() =>
    this._router.navigate(['/products', request.merchantProductNo, 'details']));
  }
}
