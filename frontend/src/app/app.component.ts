import {Component, OnInit} from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {CustomInputComponent} from "./components/custom-input/custom-input.component";
import {CustomButtonComponent} from "./components/custom-button/custom-button.component";
import {CustomCheckComponent} from "./components/custom-check/custom-check.component";
import {User} from "./models/user";
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule, ValidationErrors,
  ValidatorFn,
  Validators
} from "@angular/forms";
import {NgForOf, NgIf} from "@angular/common";
import {MatFormField, MatFormFieldModule} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {MatIcon} from "@angular/material/icon";
import {MatButton} from "@angular/material/button";
import {MAT_CHECKBOX_DEFAULT_OPTIONS, MatCheckbox, MatCheckboxDefaultOptions} from "@angular/material/checkbox";
import {MatStep, MatStepper, MatStepperNext} from "@angular/material/stepper";
import {MatOption, MatSelect, MatSelectChange} from "@angular/material/select";
import {HTTP_INTERCEPTORS, HttpClient, HttpErrorResponse} from "@angular/common/http";
import {Country, Province} from "./Interfaces/Country";
import {getSortObject} from "./scripts/sortObjectsForSelect";
import {catchError, throwError} from "rxjs";
import {UserService} from "./InterceptorService/user.service";
// import isEmail from "validator/lib/isEmail"

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    CustomInputComponent,
    CustomButtonComponent,
    CustomCheckComponent,
    ReactiveFormsModule,
    NgIf,
    MatFormField,
    MatInput,
    MatIcon,
    MatButton,
    MatFormFieldModule,
    MatCheckbox, MatStep, MatStepper, MatStepperNext, MatSelect, MatOption, NgForOf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})

export class AppComponent implements OnInit{
  title = 'frontend';
  regexPasword = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$/;
  form: FormGroup;
  isNextStep:boolean = false;
  countries: Country[] = [];
  provincies: Province[] = [];
  form2: FormGroup;
  isDisabled = true;
  selectedCountry?:string;

  constructor(private fb: FormBuilder,private http: HttpClient,private userService:UserService) {
    this.form = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.pattern(this.regexPasword)]],
      confirmPassword:['', [Validators.required]],
      isEqual:[false, [Validators.requiredTrue]]
    });
    this.form2=this.fb.group({
      countryId:['',[Validators.required]],
      provinceId:['',[Validators.required]]
    })
  }

  fetchCountries() {
    this.http.get<Country[]>('/get-countries').subscribe(
      data => {
        this.countries = data.sort((a, b) => getSortObject(a.name,b.name));
      },
      error => {
        console.error('Error fetching countries:', error);
      }
    );
  }

  fetchProvinces() {
    this.http.get<Province[]>(`/get-provincies/${this.selectedCountry}`).subscribe(
      data => {
        this.provincies = data.sort((a, b) => getSortObject(a.name,b.name));
      },
      error => {
        console.error('Error fetching countries:', error);
      }
    );
  }
  ngOnInit() {
    this.fetchCountries();
  }

  selectionChangeCountryId(e:MatSelectChange){
    this.selectedCountry = e.value;
    this.provincies=[];
    this.isDisabled=false;
  }
  onSubmit(event:Event): void {
    event.preventDefault();
    if (this.form.valid && this.form2.valid) {
      const user:User = {
        email:this.form.controls['email'].value,
        password:this.form.controls['password'].value,
        confirmPassword:this.form.controls['confirmPassword'].value,
        isAgree: this.form.controls['isEqual'].value,
        countryId:this.form2.controls['countryId'].value,
        provinceId:this.form2.controls['provinceId'].value,
      }
      this.userService.addUser(user, "/add-new-object").subscribe(data => {
        console.log('User added successfully', data);
      });
    }
  }

  openedChange(e:boolean){
    if(e){
      this.fetchProvinces();
    }
  }

  countryIdControl():FormControl{
    return this.form2.controls["countryId"] as FormControl
  }
  provinceIdControl():FormControl{
    return this.form2.controls["provinceId"] as FormControl
  }
}
