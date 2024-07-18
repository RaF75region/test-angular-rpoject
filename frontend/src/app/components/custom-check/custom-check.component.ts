import {booleanAttribute, Component, Input} from '@angular/core';

@Component({
  selector: 'app-custom-check',
  standalone: true,
  imports: [],
  templateUrl: './custom-check.component.html',
  styleUrl: './custom-check.component.scss'
})
export class CustomCheckComponent {
  @Input() id?:string;
  @Input({transform: booleanAttribute, required: true}) checked:boolean=false;
  @Input({required:true}) title?:string;

}
