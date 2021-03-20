import { VatRateTypeEnum } from "./vat-rate-type.enum";
import { ProductExtraDataModel } from "./product-extra-data.model";
import { ExtraImageUrlModel } from "./extra-image-url.model";

export class ProductModel {
    public merchantProductNo: string;
    public isActive: boolean;
    public name: string;
    public description: string;
    public brand: string;
    public size: string;
    public color: string;
    public ean: string;
    public manufacturerProductNumber: string;
    public stock: number;
    public price: number;
    public msrp: number;
    public purchasePrice: number;
    public vatRateType: VatRateTypeEnum;
    public shippingCost: number;
    public shippingTime: string;
    public url: string;
    public imageUrl: string;
    public categoryTrail: string;
    public extraData: ProductExtraDataModel[];
    public extraImageUrls: ExtraImageUrlModel[];
}