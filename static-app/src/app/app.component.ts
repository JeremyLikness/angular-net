import { Component, ViewChild, ElementRef } from '@angular/core';
import { BifurcationService } from './bifurcation.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [ BifurcationService ]
})
export class AppComponent {

  @ViewChild('mainCanvas') mainCanvasRef: ElementRef;
  context: CanvasRenderingContext2D = null;
  title = 'static-app';

  constructor(private service: BifurcationService) {

  }

  ngAfterViewInit() {
    let canvas = <HTMLCanvasElement>this.mainCanvasRef.nativeElement;
    this.context = canvas.getContext("2d");
    canvas.width = 800;
    canvas.height = 600;
    this.context.fillStyle = "rgba(0, 0, 0, 0.2)";
    this.render();
  }

  render() {
    for (let x = 0; x < 800; x += 1) {
      this.iterate_r(x);
    }
  }

  iterate_r(x: number) {
    let r = (x/800.0)*4.0;
    this.service.getPoints(r, 10, 100).subscribe(result => {
      result.forEach(x1 => {
        let y = 600 - (x1 * 600);
        this.context.fillRect(x, y, 2, 2);
      });
    });
  }
}
