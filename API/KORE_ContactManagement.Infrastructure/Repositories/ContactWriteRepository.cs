using KORE_ContactManagement.Application.Interfaces;
using KORE_ContactManagement.Application.Queries;
using KORE_ContactManagement.Domain.Entities;
using KORE_ContactManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KORE_ContactManagement.Infrastructure.Repositories
{
    public class ContactWriteRepository : IDbCommandRepository<Contact>
    {
        private readonly ApplicationDbContext _dbContext;
        public ContactWriteRepository(ApplicationDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public void Add(Contact contact)
        {
            _dbContext.Add<Contact>(contact);
            _dbContext.SaveChanges();
        }
        public void Delete(int id){
            var contact = _dbContext.Find<Contact>(id);
            _dbContext.Remove(contact);
            _dbContext.SaveChanges();
        }
        public void Update(Contact contact)
        {
            _dbContext.Update(contact);
            _dbContext.SaveChanges();
        }

        public async Task<bool> IsEmailNotExists(string email)
        {
            return await _dbContext.Contact.AnyAsync(x => x.Email != email);
        }
        public async Task<int> GetLastIndex()
        {
            var last = await _dbContext.Contact.OrderByDescending(x => x.Id).FirstOrDefaultAsync();

            return last?.Id ?? 0;
        }

        public async Task<Contact> GetById(int id)
        {
            return await _dbContext.Contact.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
