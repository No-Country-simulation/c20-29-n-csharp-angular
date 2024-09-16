import { Component, OnInit } from "@angular/core";
import {Router, RouterOutlet } from "@angular/router";
import { NavBarComponent } from "./components/nav-bar/nav-bar.component";

@Component({
	selector: "app-root",
	standalone: true,
	imports: [RouterOutlet, NavBarComponent],
	templateUrl: "./app.component.html",
	styleUrl: "./app.component.css",
})
export class AppComponent implements OnInit {
	routesWithNav: string[] = ["/patitas", "/login", "/", "/register"];
	showNavbar: boolean = false;

	constructor(private route: Router) {}
  ngOnInit(): void {
    console.log(this.routesWithNav.includes(this.route.url), this.route.url);
    console.log('here')
  }
}
