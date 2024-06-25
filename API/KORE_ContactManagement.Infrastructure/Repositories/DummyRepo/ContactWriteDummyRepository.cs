using KORE_ContactManagement.Application.Interfaces;
using KORE_ContactManagement.Application.Queries;
using KORE_ContactManagement.Domain.Entities;
using KORE_ContactManagement.Infrastructure.Configuration;
using KORE_ContactManagement.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KORE_ContactManagement.Infrastructure.Repositories.DummyRepo
{
    public class ContactWriteDummyRepository : IDbCommandRepository<Contact>
    {
        public ContactWriteDummyRepository(){

        }
        public async void Add(Contact contact)
        {
            if(!IsEmailNotExists(contact.Email).Result)
                return;
            var lastIndex = await GetLastIndex();
            contact.Id =  lastIndex + 1;
            contact.CreatedDate = DateTime.UtcNow;
            DummyData.contacts.Add(contact);
        }
        public async void Delete(int id){
            var contact = DummyData.contacts.Find(x => x.Id == id);
            DummyData.contacts.Remove(contact);
        }
        public async void Update(Contact contact)
        {
            var editContact = await GetById(contact.Id);
            editContact.FirstName = contact.FirstName;
            editContact.LastName = contact.LastName;
            editContact.PhoneNumber = contact.PhoneNumber;
            editContact.Email = contact.Email;
            editContact.Title = contact.Title;
            editContact.MiddleInitial = contact.MiddleInitial;
            editContact.ModifiedDate= DateTime.UtcNow;
        }

        public async Task<int> GetLastIndex()
        {
            var last = DummyData.contacts.OrderByDescending(y => y.Id).FirstOrDefault();

            return last?.Id ?? 0;
        }
        public async Task<Contact>? GetById(int id)
        {
            var contact = DummyData.contacts.FirstOrDefault(x => x.Id == id);
            return contact;
        }

        public async Task<bool> IsEmailNotExists(string email)
        {
            return DummyData.contacts.Any(x => x.Email != email);
        }
    }
}
