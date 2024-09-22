import { Component, OnInit } from "@angular/core";
import { NavBarComponent } from "../nav-bar/nav-bar.component";
import { PerfilUserService } from "../../services/perfil-user.service";
import { Router } from "@angular/router";
import { FormsModule } from "@angular/forms";

@Component({
	selector: "app-perfil-user",
	standalone: true,
	imports: [NavBarComponent, FormsModule],
	templateUrl: "./perfil-user.component.html",
	styleUrl: "./perfil-user.component.css",
})
export class PerfilUserComponent implements OnInit {
	id: number;
	data: any = {};
	posts: any[] = [];

	constructor(private perfilUser: PerfilUserService, private router: Router) {}

	ngOnInit(): void {
		this.perfilUser.user().subscribe({
			next: (res) => {
				this.data = res.data;
				this.id = this.data.idUsuario;
			},
			error: (e) => {
				console.log(e);
			},
		});

		this.perfilUser.post().subscribe({
			next: (res) => {
				res.map((post) => {
          if (post.idUsuario === this.id) {
            
						if (!`data:image/jpeg;base64,`.includes(post.multimediaPost)) {
							post.multimediaPost = `data:image/jpeg;base64,${post.multimediaPost}`;
							this.posts.unshift(post);
						}
					}
        });
        
			},
			error: (e) => {},
		});
	}
}
