import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TopSoldProductModel } from '../models/top-sold-product.model';
import { ListResultModel } from '../models/list-result.model';
import { ProductModel } from '../models/product.model';

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
}
