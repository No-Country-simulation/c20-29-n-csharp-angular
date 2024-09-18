import { inject } from "@angular/core";
import { CanActivateFn, Router } from "@angular/router";
import { CookieService } from "ngx-cookie-service";


export const authRouteGuard: CanActivateFn = (route, state) => {
  const cookies = inject(CookieService);
  const router = inject(Router);

  const routesNotAllowedWhitAuth = ["/patitas", "/login", "/", '/register'];

	if (routesNotAllowedWhitAuth.includes(state.url) && cookies.get("auth")) {
		if (state.url !== "/inicio") {
			router.navigateByUrl("/inicio");
		}
		return false;
  }
  
  if (!routesNotAllowedWhitAuth.includes(state.url) && !cookies.get('auth')) {
    router.navigateByUrl('/patitas')
    return false;
  }

	return true;
};
