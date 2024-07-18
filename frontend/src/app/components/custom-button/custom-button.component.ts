import {Component, Input} from '@angular/core';

type ButtonType = "submit" | "reset" | "button";
@Component({
  selector: 'app-custom-button',
  standalone: true,
  imports: [],
  templateUrl: './custom-button.component.html',
  styleUrl: './custom-button.component.scss'
})
export class CustomButtonComponent {
  @Input() type!:ButtonType;
  @Input() title!:string;
  @Input() disabled!:boolean
}
