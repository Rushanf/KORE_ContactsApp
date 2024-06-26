import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { ContactModel } from 'src/app/contact/models/contact.model';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ContactService {

  private readonly contactbaseUrl = `${environment.baseUrl}/Contact`;
  constructor(private http: HttpClient) { }

    getContacts(): Observable<ContactModel[]> {
      return this.http.get<ContactModel[]>(this.contactbaseUrl);
    }

    getContact(id: number): Observable<ContactModel> {
      return this.http.get<ContactModel>(`${this.contactbaseUrl}/${id}`);
    }

    addContact(contact: ContactModel): Observable<ContactModel> {
      return this.http.post<ContactModel>(this.contactbaseUrl, contact);
    }

    updateContact(contact: ContactModel): Observable<ContactModel> {
      return this.http.put<ContactModel>(`${this.contactbaseUrl}/${contact.id}`, contact);
    }

    deleteContact(id: number): Observable<void> {
      return this.http.delete<void>(`${this.contactbaseUrl}/${id}`);
    }
  
}

