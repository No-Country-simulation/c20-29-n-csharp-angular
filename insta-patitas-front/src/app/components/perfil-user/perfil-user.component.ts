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
imgNav: string = "";
	data: any = {};
	// format: string[] = [
	// 	"jpeg",
	// 	"png",
	// 	"gif",
	// 	"bmp",
	// 	"tiff",
	// 	"svg",
	// 	"webp",
	// 	"ico",
	// 	"heif",
	// 	"raw",
	// 	"pdf",
	// 	"apng",
	// ];
	constructor(private perfilUser: PerfilUserService, private router: Router) {}

	ngOnInit(): void {
		this.perfilUser.user().subscribe({
			next: (res) => {
        this.data = res.data;
        this.imgNav = this.data.urlFoto;

				// if (
				// 	this.data.urlFoto &&
				// 	!this.format.includes(this.data.urlFoto)
				// ) {
					this.data.urlFoto = `data:image/png;base64,${this.data.urlFoto}`;
				// }
			},
			error: (e) => {
				console.log(e);
			},
		});
	}
}

function base64ToBlob(base64: string): string | null {
	return null;
}
