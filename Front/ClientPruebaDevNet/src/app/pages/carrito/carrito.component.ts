import { Component } from '@angular/core';
import { LoaderComponent } from "../../components/loader/loader.component";

@Component({
  selector: 'app-carrito',
  imports: [LoaderComponent],
  templateUrl: './carrito.component.html',
  styleUrl: './carrito.component.css'
})
export class CarritoComponent {
  isLoading:boolean = false
}
