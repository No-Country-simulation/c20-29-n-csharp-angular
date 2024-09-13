import { Routes } from "@angular/router";
import { authRouteGuard } from "./guards/auth-route.guard";

export const routes: Routes = [
	{
		path: "",
		pathMatch: "full",
		redirectTo: "patitas",
	},
	{
		path: "patitas",
		loadComponent: () =>
			import("./pages/home/home.component").then((c) => c.HomeComponent),
	},
	{
		path: "login",
		loadComponent: () =>
			import("./auth/login/login.component").then((c) => c.LoginComponent),
	},
	{
		path: "register",
		loadComponent: () =>
			import("./auth/register/register.component").then(
				(c) => c.RegisterComponent
			),
  },
  {
    path: 'product-form',
    loadComponent: () => import('./components/product-form/product-form.component').then(c => c.ProductFormComponent),
    canActivate: [authRouteGuard]
  }
];
