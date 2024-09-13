import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-modal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './modal-post.component.html',
  styleUrls: ['./modal-post.component.css']
})
export class ModalComponent {
   // Arreglo para almacenar las opciones seleccionadas
   info: string[] = []; 

   // Objeto para controlar la visibilidad de los mensajes de ayuda
   helpVisible: { [key: string]: boolean } = {}; 
 
   // Propiedad para determinar si la opción "Adoptando" está deshabilitada
   get isAdoptandoDisabled(): boolean {
     // Deshabilita "Adoptando" si "Donando" o "Apadrinando" están seleccionados
     return this.info.includes('donando') || this.info.includes('apadrinando');
   }
 
   // Propiedad para determinar si la opción "Donando" está deshabilitada
   get isDonandoDisabled(): boolean {
     // Deshabilita "Donando" si "Adoptando" está seleccionado
     return this.info.includes('adoptando');
   }
 
   // Propiedad para determinar si la opción "Apadrinando" está deshabilitada
   get isApadrinandoDisabled(): boolean {
     // Deshabilita "Apadrinando" si "Adoptando" está seleccionado
     return this.info.includes('adoptando');
   }
 
   // Método para alternar la visibilidad de los mensajes de ayuda
   showInfo(option: string) {
     // Cambia la visibilidad del mensaje de ayuda para la opción dada
     this.helpVisible[option] = !this.helpVisible[option];
   }
 
   // Método para manejar los cambios en los checkboxes
   onCheckboxChange(option: string) {
     // Si la opción ya está en la lista, la elimina (deselecciona)
     if (this.info.includes(option)) {
       this.info = this.info.filter(item => item !== option);
     } else {
       // Si la opción no está en la lista, la añade (selecciona)
       this.info.push(option);
     }
   }
 }