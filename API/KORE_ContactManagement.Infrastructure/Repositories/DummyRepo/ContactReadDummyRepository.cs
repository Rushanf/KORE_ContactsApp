using KORE_ContactManagement.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KORE_ContactManagement.Application.Interfaces;
using KORE_ContactManagement.Domain.Entities;

namespace KORE_ContactManagement.Infrastructure.Repositories.DummyRepo
{
    internal class ContactReadDummyRepository : IDbQueryRepository<Contact>
    {
        public IEnumerable<Contact> GetAll()
        {
            return DummyData.contacts.Where(x => !String.IsNullOrWhiteSpace(x.FirstName) && 
                                            !String.IsNullOrWhiteSpace(x.LastName) && 
                                            !String.IsNullOrWhiteSpace(x.Email) && 
                                            !String.IsNullOrWhiteSpace(x.PhoneNumber))
                                .OrderBy(x => x.LastName)
                                .ThenBy(x => x.FirstName).ToList();;
        }

		public Contact Get(int id)
		{
			return DummyData.contacts.FirstOrDefault(c => c.Id == id);
		}
    }
}
