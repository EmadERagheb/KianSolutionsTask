import { Component } from '@angular/core';
import { CarouselModule } from 'ngx-bootstrap/carousel';


@Component({
  selector: 'app-slider',
  standalone: true,
  imports: [CarouselModule],
  templateUrl: './slider.component.html',
  styleUrl: './slider.component.scss'
})
export class SliderComponent {

}
