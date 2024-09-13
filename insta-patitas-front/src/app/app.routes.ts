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
    canActivate: [authRouteGuard],
  },
];
