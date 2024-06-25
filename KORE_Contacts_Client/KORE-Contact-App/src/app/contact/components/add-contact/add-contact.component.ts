import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ContactModel } from '../../models/contact.model';
import { ContactService } from 'src/app/core/services/http/contact.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.css']
})
export class AddContactComponent  implements OnInit {

  contact!: ContactModel;

  public contactForm!: FormGroup;

  constructor(private fb: FormBuilder,private contactService: ContactService, private router : Router) { }

  ngOnInit(): void {
    this.contactForm = this.fb.group({
      firstName: [this.contact?.firstName || '', Validators.required],
      lastName: [this.contact?.lastName || '', Validators.required],
      email: [this.contact?.email || '', [Validators.required, Validators.email]],
      phoneNumber: [this.contact?.phoneNumber || '', [Validators.required, Validators.pattern("^(\\+1\\s?)?(\\(\\d{3}\\)|\\d{3})[\\s.-]?\\d{3}[\\s.-]?\\d{4}$")]],
      title: [this.contact?.title || '', Validators.required],
      middleInitial: [this.contact?.middleInitial || '']
    });
  }

  onSubmit(): void {
    if (this.contactForm.valid) {
      const contactData: ContactModel = {
        ...this.contact,
        ...this.contactForm.value
      };
      this.contactService.addContact(contactData).subscribe(() => {
        this.router.navigate(['']);
      });
    }
  }
}
