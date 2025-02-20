import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ArticuloDTO, TiendaDTO } from '../../../models/models';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from "../../../components/loader/loader.component";
import { ArticuloService } from '../../../services/articulo.service';
import { TiendaService } from '../../../services/tienda.service';
import { ActivatedRoute, Router } from '@angular/router';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-articulo-form',
  imports: [CommonModule, ReactiveFormsModule, LoaderComponent],
  templateUrl: './articulo-form.component.html',
  styleUrl: './articulo-form.component.css'
})
export class ArticuloFormComponent {
  isLoading: boolean = false
  articuloForm!: FormGroup;
  tiendas: TiendaDTO[] = [];
  imagenSeleccionada: File | null = null;
  esEdicion = false;
  articuloId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private articuloService: ArticuloService,
    private tiendaService: TiendaService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

 async ngOnInit() {
    this.articuloForm = this.fb.group({
      idTiendas: [[], ],
      codigo: ['', Validators.required],
      descripcion: ['', Validators.required],
      precio: ['', [Validators.required, Validators.min(0.01)]],
      stock: ['', [Validators.required, Validators.min(1)]],
      imagen: [null]
    });

    this.tiendas = await firstValueFrom(this.tiendaService.getTiendas())

    this.route.paramMap.subscribe((params) => {
      const id = params.get('id');
      if (id) {
        this.esEdicion = true;
        this.articuloId = parseInt(id);
        this.cargarArticulo(this.articuloId);
      }
    });
    if(!this.esEdicion){
      this.articuloForm.get('idTiendas')?.setValidators([Validators.required]);
      this.articuloForm.get('idTiendas')?.updateValueAndValidity();
    }
  }

  async cargarArticulo(id: number) {
    try {
      this.isLoading = true
      let articulo: ArticuloDTO = await firstValueFrom(this.articuloService.obtenerArticuloPorId(id))
      this.articuloForm.patchValue(articulo)
    } catch (error) {

    } finally {
      this.isLoading = false
    }
  }

  onFileChange(event: any): void {
    const file = event.target.files[0];
    if (file) {
      this.imagenSeleccionada = file;
    }
  }

 async onSubmit() {
    if (this.articuloForm.invalid) return;
    try {
      this.isLoading = true;
      const formData = new FormData();

      if(!this.esEdicion)
        formData.append('idTiendas', this.articuloForm.get('idTiendas')?.value );
      formData.append('codigo', this.articuloForm.get('codigo')?.value);
      formData.append('descripcion', this.articuloForm.get('descripcion')?.value);
      formData.append('precio', this.articuloForm.get('precio')?.value);
      formData.append('stock', this.articuloForm.get('stock')?.value);

      if (this.imagenSeleccionada) {
        formData.append('imagen', this.imagenSeleccionada);
      }
      if (this.esEdicion && this.articuloId)
        await firstValueFrom(this.articuloService.editarArticulo(this.articuloId, formData))
      else
        await firstValueFrom(this.articuloService.agregarArticulo(formData))
      alert("Datos guardados correctamente")
      this.router.navigate(['/articulos']);
    } catch (error) {

    } finally {
      this.isLoading = false
    }
  }
}
