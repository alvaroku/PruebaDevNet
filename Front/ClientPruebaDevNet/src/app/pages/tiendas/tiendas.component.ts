import { Component } from '@angular/core';
import { LoaderComponent } from "../../components/loader/loader.component";

@Component({
  selector: 'app-tiendas',
  imports: [LoaderComponent],
  templateUrl: './tiendas.component.html',
  styleUrl: './tiendas.component.css'
})
export class TiendasComponent {
  isLoading:boolean = false
}
