using KORE_ContactManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KORE_ContactManagement.Application.Interfaces;
using KORE_ContactManagement.Domain.Entities;
using KORE_ContactManagement.Application;
using MediatR;

namespace KORE_ContactManagement.Infrastructure.Repositories
{
    internal class ContactReadRepository : IDbQueryRepository<Contact>
    {

        private readonly ApplicationDbContext _dbContext;

        public ContactReadRepository(ApplicationDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IEnumerable<Contact> GetAll()
        {
            return _dbContext.Contact.AsNoTracking().Where(x => !String.IsNullOrWhiteSpace(x.FirstName) && 
                                            !String.IsNullOrWhiteSpace(x.LastName) && 
                                            !String.IsNullOrWhiteSpace(x.Email) && 
                                            !String.IsNullOrWhiteSpace(x.PhoneNumber))
                                .OrderBy(x => x.LastName)
                                .ThenBy(x => x.FirstName).ToList();

        }

		public Contact? Get(int id)
		{
			return _dbContext.Contact.AsNoTracking().FirstOrDefault(c => c.Id == id);
		}
    }
}
