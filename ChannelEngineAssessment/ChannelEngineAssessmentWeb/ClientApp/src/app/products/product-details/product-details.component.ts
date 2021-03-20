import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../services/products.service';
import { ActivatedRoute } from '@angular/router';
import { ProductModel } from '../models/product.model';
import { VatRateTypeEnum } from '../models/vat-rate-type.enum';
import { SaveProductRequestModel } from '../models/save-product-request.model';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  public product: ProductModel;
  public merchantProductNo: string;
  public isSetStockModalVisible: boolean = false;
  public isUpdateModalVisible: boolean = false;
  public vatRateTypeEnum = VatRateTypeEnum;

  public constructor(private _productsService: ProductsService, private _route: ActivatedRoute) { }

  public ngOnInit(): void {
    this._route.params.subscribe(params => {
      this.merchantProductNo = params['merchantProductNo']
      console.log(this.merchantProductNo);
      this.getProduct();
    })
  }

  public getProduct(): void {
    this._productsService.getProduct(this.merchantProductNo).subscribe(x => this.product = x);
  }

  public setNewStock(newStock: number): void {
    this._productsService.setNewStock(this.merchantProductNo, newStock).subscribe(() => this.getProduct());
    this.isSetStockModalVisible = false;
  }

  public updateProduct(request: SaveProductRequestModel): void {
    this._productsService.updateProduct(request).subscribe(() =>
      this.isUpdateModalVisible = false)
  }

}
