using KORE_Contacts_Service.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace KORE_Contacts_Service.BusinessLogic
{
    public class ContactService
    {
        public static List<Contact> contacts = new List<Contact>();
        public ContactService()
        {            
        }

        public void Add(Contact contact)
        {
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
            return contacts;
        }
    }
}
