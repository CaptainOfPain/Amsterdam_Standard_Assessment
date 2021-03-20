import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ProductModel } from '../models/product.model';
import { SaveProductRequestModel } from '../models/save-product-request.model';
import { VatRateTypeEnum } from '../models/vat-rate-type.enum';

@Component({
  selector: 'app-save-product-modal',
  templateUrl: './save-product-modal.component.html',
  styleUrls: ['./save-product-modal.component.css']
})
export class SaveProductModalComponent implements OnInit {
  @Input() product: ProductModel = new ProductModel();
  @Input() isEditMode: boolean = false;
  @Output() onProductCreated: EventEmitter<SaveProductRequestModel> = new EventEmitter<SaveProductRequestModel>();
  @Output() onProductUpdated: EventEmitter<SaveProductRequestModel> = new EventEmitter<SaveProductRequestModel>();

  public vatRateTypeEnum = VatRateTypeEnum;

  public constructor() { }

  public ngOnInit(): void {
  }

  public vatRateTypeEnumValues(): string[] {
    return Object.keys(VatRateTypeEnum).filter(
      (type) => isNaN(<any>type) && type !== 'values'
    );
  }

  public create(): void {
    this.onProductCreated.emit(this.getSaveProductRequestModel());
  }

  public update(): void {
    this.onProductUpdated.emit(this.getSaveProductRequestModel());
  }

  public getSaveProductRequestModel(): SaveProductRequestModel {
    return {
      merchantProductNo: this.product.merchantProductNo,
      brand: this.product.brand,
      categoryTrail: this.product.categoryTrail,
      color: this.product.color,
      description: this.product.description,
      ean: this.product.ean,
      extraData: [],
      imageUrl: this.product.imageUrl,
      extraImageUrls: [],
      isActive: true,
      mSRP: Number(this.product.msrp),
      manufacturerProductNumber: this.product.manufacturerProductNumber,
      name: this.product.name,
      price: Number(this.product.price),
      purchasePrice: Number(this.product.purchasePrice),
      shippingCost: Number(this.product.shippingCost),
      shippingTime: this.product.shippingTime,
      size: this.product.size,
      url: this.product.url,
      vatRateType: Number(this.product.vatRateType)
    } as SaveProductRequestModel;
  }
}
