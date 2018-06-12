import { Component, ViewChild, ElementRef, OnInit } from '@angular/core';
import { fromEvent } from 'rxjs';
import { debounceTime, distinctUntilChanged,  } from 'rxjs/operators';
import { AppService } from '../../services/app.service';
import { Product } from '../../models/product';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [ AppService ]
})
export class HomeComponent implements OnInit {
  @ViewChild('filter') filter: ElementRef;

  constructor(
    public service: AppService
  ) { }

  ngOnInit() {
    fromEvent(this.filter.nativeElement, 'keyup')
      .pipe(
        debounceTime(250),
        distinctUntilChanged()
      )
      .subscribe((data: any) => {
        if (!data.target.value) {
          this.service.clearProducts();
          return;
        }

        this.service.filterProducts(data.target.value);
      });
  }

  displayProduct(p: Product) {
    return p ? p.name : null;
  }
}
