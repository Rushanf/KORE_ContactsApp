using KORE_Contacts_Service.DB;
using KORE_Contacts_Service.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace KORE_Contacts_Service.BusinessLogic
{
    public class ContactService
    {
         List<Contact> contacts = FakeDb.contacts;
        public ContactService()
        {
        }

        public void Add(Contact contact)
        {
            if(IsEmailNotExists(contact.Email))
                return;

            contact.Id = GetLastIndex() + 1;
            contact.CreatedDate = DateTime.UtcNow;
            contacts.Add(contact);
        }
        public void Delete(int id){
            var contact = contacts.Find(x => x.Id == id);
            contacts.Remove(contact);
        }
        public void Update(Contact contact)
        {
            if(IsEmailNotExists(contact.Email))
                return;

            var existingContact = GetContactById(contact.Id);
            
            existingContact.FirstName = contact.FirstName;
            existingContact.LastName = contact.LastName;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.Email = contact.Email;
            existingContact.Title = contact.Title;
            existingContact.MiddleInitial = contact.MiddleInitial;
            existingContact.ModifiedDate= DateTime.UtcNow;

        }

        public int GetLastIndex()
        {
            var last = contacts.OrderByDescending(x => x.Id).FirstOrDefault();

            return last?.Id ?? 0;
        }

        public Contact GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.Id == id);
            return contact;
        }

        public List<Contact> GetAllContacts()
        {
            return contacts.Where(x => !String.IsNullOrWhiteSpace(x.FirstName) && 
                                        !String.IsNullOrWhiteSpace(x.LastName) && 
                                        !String.IsNullOrWhiteSpace(x.Email) && 
                                        !String.IsNullOrWhiteSpace(x.PhoneNumber))
                            .OrderBy(x => x.LastName)
                            .ThenBy(x => x.FirstName).ToList();
        }

        public bool IsEmailNotExists(string email)
        {
            return contacts.Any(x => x.Email != email);
        }
    }
}
