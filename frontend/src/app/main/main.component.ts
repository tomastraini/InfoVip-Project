import { Component, OnDestroy, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { HttpClient } from '@angular/common/http';
import { interval, Subscription } from 'rxjs';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit, OnDestroy {

  constructor(private http: HttpClient, private appComponent: AppComponent)
  {

  }

  searchvalue: any;
  subscription: Subscription | undefined
  route = this.appComponent.apiUrl;
  CryptoPrices: any;
  cryptoCoins: any;


  amount = 1;

  updateCryptos()
  {
    this.http.get<any>(this.route + 'Cryptos').subscribe(res =>{
      this.CryptoPrices = res;
      res.data.coins.forEach((c: any) => {
        c.priceCalculated = c.quote.usd.price;
      });
      this.cryptoCoins = res.data.coins;
    });
  }

  onModalOpen()
  {

  }


  ngOnInit(): void
  {
    this.updateCryptos();
    const source = interval(20000);

    this.subscription = source.subscribe(val => this.updateCryptos());

  }

  ngOnDestroy(): void {
    this.subscription?.unsubscribe();
  }

  calculatePrice()
  {
    this.cryptoCoins.forEach((c: any) => {
      c.priceCalculated = c.quote.usd.price * this.amount;
    });
  }
}
