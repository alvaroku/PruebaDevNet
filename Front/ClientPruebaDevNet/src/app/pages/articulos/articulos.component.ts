import { Component } from '@angular/core';
import { LoaderComponent } from "../../components/loader/loader.component";

@Component({
  selector: 'app-articulos',
  imports: [LoaderComponent],
  templateUrl: './articulos.component.html',
  styleUrl: './articulos.component.css'
})
export class ArticulosComponent {
  isLoading:boolean = false
}
