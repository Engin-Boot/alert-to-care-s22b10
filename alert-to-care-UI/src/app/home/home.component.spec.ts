import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Component, Inject, OnInit } from '@angular/core';
import {Router} from '@angular/router'
import { AccountService } from '../services/account.service';
import { HomeComponent } from './home.component';

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeComponent ],
      imports:[Component, Inject,Router,AccountService],
      providers:[Component, Inject,Router,AccountService]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
