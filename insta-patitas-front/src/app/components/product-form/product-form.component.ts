import { JsonPipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'product-form',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, JsonPipe],
  templateUrl: './product-form.component.html',
  styleUrl: './product-form.component.css',
})
export class ProductFormComponent implements OnInit {
  productForm: FormGroup;

  // Inyectamos la clase FormBuilder para construir el formulario(FormGroup)
  constructor(private formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.productForm = this.formBuilder.group({
      nameOrCompanyName: '',
      productOrService: '',
      telephone: '',
      email: '',
      vetLicence: '',
      servicesDescription: '',
      taxIdentification: '',
      productsDescription: '',
      personReference: '',
      phoneReference: '',
      socialNetwork: '',
      documentation: '',
      termsConditions: '',
    });

    // Nos suscribimos a los cambios que ocurran al formulario
    this.productForm.valueChanges.subscribe((response) =>
      console.log(response)
    );
  }

  // Metodos Getter para obtener los datos insertados en los campos del html
  get nameOrCompanyname() {
    return this.productForm.get('nameOrCompanyName');
  }
  get productOrService() {
    return this.productForm.get('productOrService');
  }
  get telephone() {
    return this.productForm.get('telephone');
  }
  get email() {
    return this.productForm.get('email');
  }
  get vetLicence() {
    return this.productForm.get('vetLicence');
  }
  get servicesDescription() {
    return this.productForm.get('servicesDescription');
  }
  get taxIdentification() {
    return this.productForm.get('taxIdentification');
  }
  get productsDescription() {
    return this.productForm.get('productsDescription');
  }
  get personReference() {
    return this.productForm.get('personReference');
  }
  get phoneReference() {
    return this.productForm.get('phoneReference');
  }
  get socialNetwork() {
    return this.productForm.get('socialNetwork');
  }
  get documentation() {
    return this.productForm.get('documentation');
  }
  get termsConditions() {
    return this.productForm.get('termsConditions');
  }
}
