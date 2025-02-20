import { Component, OnInit } from '@angular/core';
import { LoaderComponent } from "../../../components/loader/loader.component";
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { TiendaService } from '../../../services/tienda.service';
import { ActivatedRoute, Router } from '@angular/router';
import { TiendaDTO, TiendaRequestDTO } from '../../../models/models';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-tienda-form',
  imports: [LoaderComponent, CommonModule, ReactiveFormsModule],
  templateUrl: './tienda-form.component.html',
  styleUrl: './tienda-form.component.css'
})
export class TiendaFormComponent implements OnInit {
  isLoading: boolean = false
  tiendaForm!: FormGroup;
  esEdicion = false;
  tiendaId: number | null = null;

  constructor(
    private fb: FormBuilder,
    private tiendaService: TiendaService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

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

  async cargarTienda() {
    try {
      this.isLoading = true
      let tienda: TiendaDTO = await firstValueFrom(this.tiendaService.getTiendaIdPorId(this.tiendaId!))
      this.tiendaForm.patchValue(tienda);
    } catch (error) {

    } finally {
      this.isLoading = false
    }
  }

  async guardar() {
    if (this.tiendaForm.invalid) return;

    const tienda: TiendaRequestDTO = this.tiendaForm.value
    try {
      this.isLoading = true

      if (this.esEdicion) {
        await firstValueFrom(this.tiendaService.actualizarTienda(this.tiendaId ?? 0, tienda))
        alert('Tienda actualizada correctamente');
        this.router.navigate(['/tiendas']);

      } else {
        await firstValueFrom(this.tiendaService.crearTienda(tienda))
        alert('Tienda creada correctamente');
        this.router.navigate(['/tiendas']);
      }

    } catch (error) {

    } finally {
      this.isLoading = false
    }

  }
}
