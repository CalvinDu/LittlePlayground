import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  OnClick(): void {
    print();
  }

  printTest(): void {
    let printContents, popupWin;
    printContents = document.getElementById('print-section').innerHTML;
    popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
    popupWin.document.write(`
      <html>
        <head>
          <title>Print tab</title>
          <style>
          </style>
        </head>
    <body onload="window.print();window.close()">${printContents}</body>
      </html>`
    );
  }
}
