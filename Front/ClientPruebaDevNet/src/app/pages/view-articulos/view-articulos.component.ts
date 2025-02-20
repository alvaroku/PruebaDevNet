import { Component } from '@angular/core';
import { LoaderComponent } from "../../components/loader/loader.component";

@Component({
  selector: 'app-view-articulos',
  imports: [LoaderComponent],
  templateUrl: './view-articulos.component.html',
  styleUrl: './view-articulos.component.css'
})
export class ViewArticulosComponent {
  isLoading:boolean = false
}
