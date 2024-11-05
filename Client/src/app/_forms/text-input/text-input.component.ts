import { NgClass, NgIf, TitleCasePipe } from '@angular/common';
import { Component, input, OnChanges, Self, SimpleChanges } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-text-input',
  standalone: true,
  imports: [TitleCasePipe,ReactiveFormsModule,NgClass,NgIf],
  templateUrl: './text-input.component.html',
  styleUrl: './text-input.component.scss'
})
export class TextInputComponent implements ControlValueAccessor ,OnChanges {
  inputType = input<string>('text');
  color = input<string>();
  isTransparent = input<boolean>(false);
  label = input.required<string>();
  showValidation = input<boolean>(true)
  type = 'text';

  constructor(@Self() public ngControl: NgControl) {
    this.ngControl.valueAccessor = this;
  }
  ngOnChanges(changes: SimpleChanges): void {
    this.type = this.inputType();
  }
  writeValue(obj: any): void {}
  registerOnChange(fn: any): void {}
  registerOnTouched(fn: any): void {}
  setDisabledState?(isDisabled: boolean): void {}
  get control(): FormControl {
    return this.ngControl.control as FormControl;
  }
  toggleIcon() {
    if (this.type == 'password') {
      this.type = 'text';
    } else {
      this.type = 'password';
    }
  }
}
