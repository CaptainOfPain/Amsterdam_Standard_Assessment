import { ProductExtraDataModel } from "./product-extra-data.model";
import { VatRateTypeEnum } from "./vat-rate-type.enum";

export type SaveProductRequestModel = {
    merchantProductNo: string;
    isActive: boolean;
    extraData: ProductExtraDataModel[];
    name: string;
    description: string;
    brand: string;
    size: string;
    color: string;
    ean: string;
    manufacturerProductNumber: string;
    price: number;
    mSRP: number;
    purchasePrice: number;
    vatRateType: VatRateTypeEnum;
    shippingCost: number;
    shippingTime: string;
    url: string;
    imageUrl: string;
    extraImageUrls: string[];
    categoryTrail: string;
}