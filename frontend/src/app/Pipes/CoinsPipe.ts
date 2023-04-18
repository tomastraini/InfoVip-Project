import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'CoinsPipe'
})
export class CoinsPipe implements PipeTransform {

  transform(li: any[], value: string): any {
   return value !== undefined && li !== undefined ? li.filter(val =>
      val.id.toString().indexOf(value) !== -1 ||

      val.name.indexOf(value) !== -1 ||

      val.priceCalculated.toString().indexOf(value) !== -1 ||

      val.id.toString().toLowerCase().indexOf(value.toLowerCase()) !== -1 ||

      val.name.toLowerCase().indexOf(value.toLowerCase()) !== -1 ||

      val.priceCalculated.toString().toLowerCase().indexOf(value.toLowerCase()) !== -1
      
    ) : li;
  }
}