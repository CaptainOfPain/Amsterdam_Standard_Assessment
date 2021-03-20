import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TopSoldProductModel } from '../models/top-sold-product.model';
import { ListResultModel } from '../models/list-result.model';
import { ProductModel } from '../models/product.model';
import { SaveProductRequestModel } from '../models/save-product-request.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  public constructor(private _http: HttpClient, @Inject('BASE_URL')  private _baseUrl: string) { }

  public getTopSoldProducts(): Observable<ListResultModel<TopSoldProductModel>> {
    return this._http.get<ListResultModel<TopSoldProductModel>>(this._baseUrl + 'products/topSold');
  }

  public getProduct(merchantProductNo: string): Observable<ProductModel> {
    return this._http.get<ProductModel>(this._baseUrl + 'products/' + merchantProductNo);
  }

  public setNewStock(merchantProductNo: string, newStock: number): Observable<void> {
    return this._http.patch<void>(this._baseUrl + 'products/', {merchantProductNo, newStock});
  }

  public createProduct(request: SaveProductRequestModel): Observable<void> {
    return this._http.post<void>(this._baseUrl + 'products/', request);
  }

  public updateProduct(request: SaveProductRequestModel): Observable<void> {
    return this._http.put<void>(this._baseUrl + 'products/', request);
  }
}
