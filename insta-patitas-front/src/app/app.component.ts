import { Component, OnInit } from "@angular/core";
import {Router, RouterOutlet } from "@angular/router";
import { NavBarComponent } from "./components/nav-bar/nav-bar.component";
import { CreatePostComponent } from "./components/create-post/create-post.component";

@Component({
	selector: "app-root",
	standalone: true,
	imports: [RouterOutlet, NavBarComponent, CreatePostComponent],
	templateUrl: "./app.component.html",
	styleUrl: "./app.component.css",
})
export class AppComponent implements OnInit {

	constructor() {}
  ngOnInit(): void {
  }
}
