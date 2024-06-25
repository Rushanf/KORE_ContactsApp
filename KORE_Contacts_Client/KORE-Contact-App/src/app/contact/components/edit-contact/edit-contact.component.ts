import { Component, EventEmitter, Inject, Input, Output } from '@angular/core';
import { ContactModel } from '../../models/contact.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContactService } from 'src/app/core/services/http/contact.service';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-edit-contact',
  templateUrl: './edit-contact.component.html',
  styleUrls: ['./edit-contact.component.css']
})
export class EditContactComponent {
  
  public contact: ContactModel = new ContactModel();
  
  public contactForm!: FormGroup;
  private subscription: Subscription | undefined;
      
  constructor(private fb: FormBuilder,private contactService: ContactService, private router : Router, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.contactForm = this.fb.group({
      firstName: [this.contact?.firstName || '', Validators.required],
      lastName: [this.contact?.lastName || '', Validators.required],
      email: [this.contact?.email || '', [Validators.required, Validators.email]],
      phoneNumber: [this.contact?.phoneNumber || '', [Validators.required, Validators.pattern("^(\\+1\\s?)?(\\(\\d{3}\\)|\\d{3})[\\s.-]?\\d{3}[\\s.-]?\\d{4}$")]],
      title: [this.contact?.title || '', Validators.required],
      middleInitial: [this.contact?.middleInitial || '']
    });

    this.subscription = this.route.params.subscribe(params => {
      const id = params['id'];
      this.loadContact(id);
    })
  }

  loadContact(id : number): void {
    this.contactService.getContact(id).subscribe(contact => {
      this.contact = contact;
    });
  }

  onSubmit(): void {
    if (this.contactForm.valid) {
      const contactData: ContactModel = {
        ...this.contact,
        ...this.contactForm.value
      };
      this.contactService.updateContact(contactData).subscribe(() => {        
         this.router.navigate(['']);
      });
    }
  }

  ngOnDestroy(): void {
    if (this.subscription)
      this.subscription.unsubscribe()
  }
  
}
