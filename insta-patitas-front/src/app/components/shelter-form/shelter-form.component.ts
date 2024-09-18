import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';

@Component({
  selector: 'app-shelter-form',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './shelter-form.component.html',
  styleUrl: './shelter-form.component.css',
})
export class ShelterFormComponent implements OnInit {
  shelterForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {}
  ngOnInit(): void {
    this.shelterForm = this.formBuilder.group({
      shelterName: '',
      organizationType: '',
      foundationYear: '',
      nameAndLastNames: '',
      dni: '',
      phoneNumber: '',
      email: '',
      referencesName: '',
      referencesPhoneNumber: '',
      documentation: '',
      termsConditions: '',
    });

    this.shelterForm.valueChanges.subscribe((response) =>
      console.log(response)
    );
  }

  get shelterName() {
    return this.shelterForm.get('shelterName');
  }

  get organizationType() {
    return this.shelterForm.get('organizationType');
  }

  get foundationYear() {
    return this.shelterForm.get('foundationYear');
  }

  get nameAndLastNames() {
    return this.shelterForm.get('nameAndLastNames');
  }

  get dni() {
    return this.shelterForm.get('dni');
  }

  get phoneNumber() {
    return this.shelterForm.get('phoneNumber');
  }

  get referencesName() {
    return this.shelterForm.get('referencesName');
  }

  get email() {
    return this.shelterForm.get('email');
  }

  get documentation() {
    return this.shelterForm.get('documentation');
  }

  get termsConditions() {
    return this.shelterForm.get('termsConditions');
  }

  get referencesPhoneNumber() {
    return this.shelterForm.get('referencesPhoneNumber');
  }
}
