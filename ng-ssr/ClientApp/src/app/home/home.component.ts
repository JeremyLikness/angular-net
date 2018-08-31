import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  os: string = null;

  constructor(@Inject('OS') public osinject: string) {
    console.log(osinject);
    this.os = osinject;
  }
}
