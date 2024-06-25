import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactListComponent } from './contact/components/contact-list/contact-list.component';
import { AddContactComponent } from './contact/components/add-contact/add-contact.component';
import { EditContactComponent } from './contact/components/edit-contact/edit-contact.component';

const routes: Routes = [
  
  {
    path: 'create',
    component: AddContactComponent,
  },
  {    
    path: 'edit/:id',
    component: EditContactComponent,
  },
  {
    path: '',
    component: ContactListComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
