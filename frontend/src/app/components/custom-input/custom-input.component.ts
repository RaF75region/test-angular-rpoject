import {booleanAttribute, Component, EventEmitter, forwardRef, Input, OnChanges, OnInit, Output} from '@angular/core';
import {
  ControlValueAccessor,
  FormControl,
  FormGroup,
  NG_VALUE_ACCESSOR,
  ReactiveFormsModule,
} from "@angular/forms";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-custom-input',
  standalone: true,
  imports: [
    NgIf,
    ReactiveFormsModule
  ],
  templateUrl: './custom-input.component.html',
  styleUrl: './custom-input.component.scss',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => CustomInputComponent),
      multi: true,
    },
  ],
})
export class CustomInputComponent implements ControlValueAccessor{
  @Input() placeholder!:string;
  @Input() helpText!:string;
  @Input() type!:string;
  @Input() id!:string;
  @Input() label!:string;
  @Input({transform: booleanAttribute}) required:boolean=false;
  @Input() feedback!:string;
  @Input() validText!:string;
  @Input() control!: FormControl;
  @Input() formControlName!: string;
  @Input() formGroup!:FormGroup
  value!: string;
  onChange: any = () => {};
  onTouched: any = () => {};

  writeValue(value: any): void {
    this.value = value;
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  onInput(event: Event): void {
    const input = event.target as HTMLInputElement;
    const value = input.value;
    this.value = value;
    this.onChange(value);
    this.updateFormControl(value);

  }

  setDisabledState?(isDisabled: boolean): void {
    if (isDisabled) {
      this.control.disable();
    } else {
      this.control.enable();
    }
  }


  private updateFormControl(value: string): void {
      if (this.control && this.control.value !== value) {
        this.control.setValue(value, { emitEvent: false });
      }
  }

}
