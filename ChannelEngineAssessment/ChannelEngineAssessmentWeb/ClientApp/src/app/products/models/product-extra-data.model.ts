export class ProductExtraDataModel {
    public key: string;
    public value: string;
    public type: ProductExtraDataTypeEnum;
    public isPublic: boolean;
}

export enum ProductExtraDataTypeEnum {
    Text = 1,
    Number = 2,
    Url = 3,
    ImageUrl = 4
}