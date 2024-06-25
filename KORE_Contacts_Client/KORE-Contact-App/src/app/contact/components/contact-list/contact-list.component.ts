import { Component, OnInit, ViewChild } from '@angular/core';
import { ContactModel } from '../../models/contact.model';
import { ContactService } from 'src/app/core/services/http/contact.service';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-contact-list',
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {

  contacts: ContactModel[] = [];
  searchTerm: string = '';
  filteredContacts: ContactModel[] = [];
  pageSize: number = 10;
  pageIndex: number = 0;
  filteredCount: number = 0;
  public selectedContact: ContactModel =  new ContactModel();
  displayEdit = false;

  @ViewChild(MatPaginator) paginator: MatPaginator | undefined;
  
  constructor(private contactService: ContactService, private router : Router) {}

  ngOnInit(): void {
    this.loadContacts();
  }

  loadContacts(): void {
    this.contactService.getContacts().subscribe(contacts => {
      this.contacts = contacts;
      this.applyFilterAndPagination();
    });
  }

  applyFilterAndPagination(): void {
    const filtered = this.contacts.filter(contact =>
      Object.keys(contact).some(key =>
        contact[key as keyof ContactModel]?.toString().toLowerCase().includes(this.searchTerm.toLowerCase())
      )
    );

    this.filteredCount = filtered.length;
    this.filteredContacts = filtered.slice(this.pageIndex * this.pageSize, (this.pageIndex + 1) * this.pageSize);
  }

  onSearchTermChange(): void {
    this.pageIndex = 0;
    this.applyFilterAndPagination();
  }

  onPageChange(event: PageEvent): void {
    this.pageSize = event.pageSize;
    this.pageIndex = event.pageIndex;
    this.applyFilterAndPagination();
  }

  create(){
    this.router.navigate(['/create']);
  }

  deleteContact(id: number): void {
    this.contactService.deleteContact(id).subscribe(() => {
      this.loadContacts();
    });
  }

  editContact(contact: ContactModel): void {
    this.router.navigate(['/edit/'+ contact.id]);    
  }
}
