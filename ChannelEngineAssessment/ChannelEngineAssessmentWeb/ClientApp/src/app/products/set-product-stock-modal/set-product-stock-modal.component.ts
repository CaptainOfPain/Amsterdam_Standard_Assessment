import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-set-product-stock-modal',
  templateUrl: './set-product-stock-modal.component.html',
  styleUrls: ['./set-product-stock-modal.component.css']
})
export class SetProductStockModalComponent implements OnInit {
  @Output() onNewStockSetted: EventEmitter<number> = new EventEmitter<number>();

  public constructor() { }

  public ngOnInit() : void {
  }

  public setNewStock(newStock: number): void {
    this.onNewStockSetted.emit(newStock);
  }

}
