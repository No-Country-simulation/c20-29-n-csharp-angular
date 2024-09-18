import { Component, inject, OnInit } from "@angular/core";
import { NavBarComponent } from "../nav-bar/nav-bar.component";
import { HeaderComponent } from "../header/header.component";
import { ScrollService } from "../../services/scroll.service";
import { AsyncPipe, CommonModule, NgFor, NgIf } from "@angular/common";
import { Post } from "../../interfaces/post";

@Component({
	selector: "app-scroll",
	standalone: true,
	imports: [NavBarComponent, HeaderComponent, NgIf, NgFor, AsyncPipe],
	templateUrl: "./scroll.component.html",
	styleUrl: "./scroll.component.css",
})
export class ScrollComponent implements OnInit {

  posts : any[] = [];

	constructor(private scrollService: ScrollService) {}

  ngOnInit(): void {
		this.scrollService.getAllPost().subscribe({
			next: (res) => {
				res.map((post) => {
					if (!`data:image/png;base64,`.includes(post.multimediaPost)) {
            post.multimediaPost = `data:image/png;base64,${post.multimediaPost}`;
					}
				});

				this.posts = res;
			},
			error: (err) => {
				console.error("error");
			},
    });
    
	}
}
