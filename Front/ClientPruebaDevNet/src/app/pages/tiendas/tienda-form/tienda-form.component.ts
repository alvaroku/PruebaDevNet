import { Component, OnInit } from '@angular/core';
import { LoaderComponent } from "../../../components/loader/loader.component";
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { TiendaService } from '../../../services/tienda.service';
import { ActivatedRoute, Router } from '@angular/router';
import { TiendaDTO, TiendaRequestDTO } from '../../../models/models';

@Component({
  selector: 'app-tienda-form',
  imports: [LoaderComponent,CommonModule,ReactiveFormsModule],
  templateUrl: './tienda-form.component.html',
  styleUrl: './tienda-form.component.css'
})
export class TiendaFormComponent implements OnInit {
  isLoading:boolean = false
  tiendaForm!: FormGroup;
  esEdicion = false;
  tiendaId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private tiendaService: TiendaService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.tiendaId = this.route.snapshot.params['id'] ? +this.route.snapshot.params['id'] : null;
    this.esEdicion = this.tiendaId !== null;

    this.tiendaForm = this.fb.group({
      sucursal: ['', Validators.required],
      direccion: ['', Validators.required]
    });

    if (this.esEdicion) {
      this.cargarTienda();
    }
  }

  cargarTienda(): void {
    this.tiendaService.getTiendaIdPorId(this.tiendaId!).subscribe((tienda: TiendaDTO) => {
      this.tiendaForm.patchValue(tienda);
    });
  }

  guardar(): void {
    if (this.tiendaForm.invalid) return;

    const tienda: TiendaRequestDTO = this.tiendaForm.value

    if (this.esEdicion) {
      this.tiendaService.actualizarTienda(this.tiendaId??0,tienda).subscribe(() => {
        alert('Tienda actualizada correctamente');
        this.router.navigate(['/tiendas']);
      });
    } else {
      this.tiendaService.crearTienda(tienda).subscribe(() => {
        alert('Tienda creada correctamente');
        this.router.navigate(['/tiendas']);
      });
    }
  }
}
