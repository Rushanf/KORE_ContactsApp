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
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, ContactModel>
    {
        IDbQueryRepository<Contact> _dbQueryRepository;

        public GetContactQueryHandler(IDbQueryRepository<Contact> dbQueryRepository)
        {
            _dbQueryRepository = dbQueryRepository;
        }

        public Task<ContactModel> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var contact = _dbQueryRepository.Get(request.Id);
                        
            ContactModel contactVM = new()
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                MiddleInitial = contact.MiddleInitial,
                PhoneNumber = contact.PhoneNumber,
                Title = contact.Title
            };
                
            
            return Task.FromResult(contactVM);
        }

        
    }
}
