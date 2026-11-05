import { Pipe, PipeTransform } from '@angular/core';
import { Artist } from '../models/artist/artist.interface';

@Pipe({
  name: 'yearsOfLife',
})
export class YearsOfLifePipe implements PipeTransform {

  transform(value: Artist, ...args: unknown[]): unknown {
    if (value.yearOfBirth && value.yearOfDeath) {
      return `(${value.yearOfBirth} - ${value.yearOfDeath})`;
    } else {
      return `(${value.yearOfBirth})`;
    }
  }
  
}