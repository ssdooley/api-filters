import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { SnackerService } from './snacker.service';
import { Product } from '../models/product';

@Injectable()
export class AppService {
  private products = new BehaviorSubject<Product[]>(null);
  products$ = this.products.asObservable();

  constructor(
    private http: HttpClient,
    private snacker: SnackerService
  ) { }

  filterProducts(search: string) {
    this.http.get<Product[]>(`/api/app/filterProducts/${search}`)
      .subscribe(
        data => this.products.next(data),
        err => this.snacker.sendErrorMessage(err)
      );
  }

  clearProducts() {
    this.products.next(null);
  }
}
