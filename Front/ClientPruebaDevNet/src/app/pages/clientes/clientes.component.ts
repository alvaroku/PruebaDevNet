import { Component } from '@angular/core';
import { LoaderComponent } from "../../components/loader/loader.component";

@Component({
  selector: 'app-clientes',
  imports: [LoaderComponent],
  templateUrl: './clientes.component.html',
  styleUrl: './clientes.component.css'
})
export class ClientesComponent {
  isLoading:boolean = false
}
