import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: []
})
export class AppComponent {
    title = 'InfoSellersAngular';
    version = `${VERSION.major}.${VERSION.minor}`;
}