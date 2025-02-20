import { Routes } from '@angular/router';
import { ClientesComponent } from './pages/clientes/clientes.component';
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

export const routes: Routes = [

  {
    path: '', component: MenuComponent,
    children: [
      { path: 'home', component: HomeComponent },
      { path: '', redirectTo: "home", pathMatch: 'full' },
      { path: 'clientes', component: ClientesComponent },
      { path: 'tiendas', component: TiendasComponent },
      { path: 'articulos', component: ArticulosComponent },
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
