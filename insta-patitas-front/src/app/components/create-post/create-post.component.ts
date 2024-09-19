import { Component, OnInit } from "@angular/core";
import { CreatePostService } from "../../services/create-post.service";
import { Router } from "@angular/router";
import { NavBarComponent } from "../nav-bar/nav-bar.component";

@Component({
	selector: "app-create-post",
	standalone: true,
	imports: [NavBarComponent],
	templateUrl: "./create-post.component.html",
	styleUrl: "./create-post.component.css",
})
export class CreatePostComponent implements OnInit {
  post: string | ArrayBuffer;
  img: any;

	constructor(
		private createService: CreatePostService,
		private router: Router
	) {}

	ngOnInit(): void {}

	cargarPost(event: Event) {
		const input = event.target as HTMLInputElement;

    if (input.files && input.files[0]) {
      this.img = input.files[0];
			const reader = new FileReader();

      reader.onload = () => {
        this.post = reader.result;
			};

			reader.readAsDataURL(input.files[0]);
		}
	}

	sendPost(event: Event) {
    event.preventDefault();
    
		const form = new FormData(event.target as HTMLFormElement);

    if (form.get("description") && form.get("type_post") && this.post) {
      
			let data = {
				description: form.get("description"),
        type: form.get("type_post"),
        img: this.img
			};

			this.createService.post(data).subscribe({
        next: (res) => {
					this.router.navigateByUrl("/inicio");
				},
				error: (e) => {
					console.log(e);
				},
			});
		} else {
			console.log("Faltan datos");
		}
	}
}


// Con esto quitariamos el mime del base64
function whitoutMime(base64: string | ArrayBuffer) {
	let img: string = "";

	if (typeof base64 === "string") {
		let arrayBase64 = base64.split(",");

		img = arrayBase64[1];
	}
	return [img];
}
