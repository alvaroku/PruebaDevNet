import { Routes } from '@angular/router';
import { ClientesComponent } from './pages/usuarios/usuarios.component';
import { TiendasComponent } from './pages/tiendas/tiendas.component';
import { ArticulosComponent } from './pages/articulos/articulos.component';
import { ViewArticulosComponent } from './pages/view-articulos/view-articulos.component';
import { CarritoComponent } from './pages/carrito/carrito.component';
import { RegistroComponent } from './pages/registro/registro.component';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { MenuComponent } from './pages/layout/menu/menu.component';
import { SimpleComponent } from './pages/layout/simple/simple.component';
import { LogoutComponent } from './pages/logout/logout.component';
import { ArticuloFormComponent } from './pages/articulos/articulo-form/articulo-form.component';
import { ArticulosTiendaComponent } from './pages/tiendas/articulos-tienda/articulos-tienda.component';
import { UsuarioFormComponent } from './pages/usuarios/usuario-form/usuario-form.component';
import { TiendaFormComponent } from './pages/tiendas/tienda-form/tienda-form.component';

export const routes: Routes = [

  {
    path: '', component: MenuComponent,
    children: [
      { path: 'home', component: HomeComponent },
      { path: '', redirectTo: "home", pathMatch: 'full' },

      { path: 'clientes', component: ClientesComponent },
      { path: 'form-cliente/:id', component: UsuarioFormComponent },
      { path: 'form-cliente', component: UsuarioFormComponent },

      { path: 'tiendas', component: TiendasComponent },
      { path: 'form-tienda/:id', component: TiendaFormComponent },
      { path: 'form-tienda', component: TiendaFormComponent },


      { path: 'articulos', component: ArticulosComponent },
      { path: 'form-articulo/:id', component: ArticuloFormComponent },
      { path: 'form-articulo', component: ArticuloFormComponent },
      { path: 'articulos-tienda/:id', component: ArticulosTiendaComponent },

      { path: 'view-articulos', component: ViewArticulosComponent },
      { path: 'carrito', component: CarritoComponent },
      { path: 'logout', component: LogoutComponent },
    ]
  },
  {
    path: '', component: SimpleComponent,
    children: [
      { path: 'registro', component: RegistroComponent },
      { path: 'login', component: LoginComponent },
    ]
  }
];
