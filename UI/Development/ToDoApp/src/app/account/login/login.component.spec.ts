import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginComponent } from './login.component';
import { DebugElement } from '@angular/core';
import { By } from '@angular/platform-browser';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;
  let submitEl: DebugElement;
  let loginEl: DebugElement;
  let passwordEl: DebugElement;
  
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoginComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;

    submitEl = fixture.debugElement.query(By.css('button'));
    loginEl = fixture.debugElement.query(By.css('input[type=text]'));
    passwordEl = fixture.debugElement.query(By.css('input[type=password]'));
    
    fixture.detectChanges();
  });

  it('Setting enabled to false disabled the submit button', () => {
        component.loading = false;
        fixture.detectChanges();
        expect(submitEl.nativeElement.disabled).toBeTruthy();
    });

  it('Setting enabled to true enables the submit button', () => {
        component.loading = true;
        fixture.detectChanges();
        expect(submitEl.nativeElement.disabled).toBeFalsy();
    });

  // it('Entering email and password emits loggedIn event', () => {
  //       loginEl.nativeElement.value = 'tanju';
  //       passwordEl.nativeElement.value = 'Tushar@123';

  //       spyOn(AuthenticationService, 'login').and.returnValue(mockUser);

  //       // This sync emits the event and the subscribe callback gets executed above
  //       submitEl.triggerEventHandler('click', null);
  //   });
});
