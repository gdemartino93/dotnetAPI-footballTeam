import {Pipe , PipeTransform} from '@angular/core'
@Pipe({
  name : 'million'
})
export class MillionPipe implements PipeTransform{
  transform(value: number) : number {
    const millionValue = value * 1000000;
    return millionValue;

  }
}
