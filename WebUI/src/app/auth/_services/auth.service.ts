import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseHttpService } from 'src/app/@shared/_services/base-http.service';
import { LoginDto } from '../_models/login-dto';
import { RegisterDto } from '../_models/register-dto';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseHttpService {

  constructor(http: HttpClient) {
    super(http);
  }

  login(loginDto: LoginDto): Observable<any> {
    return this.Post('Account/Login', loginDto);
  }

  register(registerDto: RegisterDto): Observable<any> {
    return this.Post('Account/Register', registerDto);
  }
}
