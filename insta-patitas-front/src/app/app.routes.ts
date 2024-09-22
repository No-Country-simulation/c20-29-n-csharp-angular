import { Routes } from "@angular/router";
import { authRouteGuard } from "./guards/auth-route.guard";

export const routes: Routes = [
	{
		path: "",
		pathMatch: "full",
		redirectTo: "/patitas",
	},
	{
		path: "patitas",
		loadComponent: () =>
      import("./pages/home/home.component").then((c) => c.HomeComponent),
    canActivate:[authRouteGuard]
	},
	{
		path: "login",
		loadComponent: () =>
      import("./auth/login/login.component").then((c) => c.LoginComponent),
    canActivate: [authRouteGuard]
	},
	{
		path: "register",
		loadComponent: () =>
			import("./auth/register/register.component").then(
        (c) => c.RegisterComponent
      ),
    canActivate: [authRouteGuard]
	},
	{
		path: "product-form",
		loadComponent: () =>
			import("./components/product-form/product-form.component").then(
				(c) => c.ProductFormComponent
			),
		canActivate: [authRouteGuard]
	},
	{
		path: "perfil-user",
		loadComponent: () =>
			import("./components/perfil-user/perfil-user.component").then(
				(c) => c.PerfilUserComponent
			),
		canActivate: [authRouteGuard]
	},
	{
		path: "inicio",
		loadComponent: () =>
			import("./components/scroll/scroll.component").then(
				(c) => c.ScrollComponent
      ),
    canActivate: [authRouteGuard]
	},
	{
		path: "create-post",
		loadComponent: () =>
			import("./components/create-post/create-post.component").then(
				(c) => c.CreatePostComponent
      ),
    canActivate: [authRouteGuard]
	},
];
