using KORE_ContactManagement.Application.Interfaces;
using KORE_ContactManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KORE_ContactManagement.Application.Queries
{
    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, List<ContactModel>>
    {
        IDbQueryRepository<Contact> _dbQueryRepository;

        public GetAllContactsQueryHandler(IDbQueryRepository<Contact> dbQueryRepository)
        {
            _dbQueryRepository = dbQueryRepository;
        }

        public Task<List<ContactModel>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            List<ContactModel> contactVMs = new List<ContactModel>();
            var contacts = _dbQueryRepository.GetAll();

            foreach (var item in contacts)
            {
                ContactModel contactVM = new()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    MiddleInitial = item.MiddleInitial,
                    PhoneNumber = item.PhoneNumber,
                    Title = item.Title
                };
                
                contactVMs.Add(contactVM);
            }
            
            return Task.FromResult(contactVMs);
        }

        
    }
}
