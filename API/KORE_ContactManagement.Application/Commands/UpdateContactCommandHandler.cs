using KORE_ContactManagement.Application.Interfaces;
using KORE_ContactManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KORE_ContactManagement.Application.Commands
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Result>
    {
        IDbCommandRepository<Contact> _dbCommandRepository;

        public UpdateContactCommandHandler(IDbCommandRepository<Contact> dbCommandRepository)
        {
            _dbCommandRepository = dbCommandRepository;
        }
        public async Task<Result> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        { 
            try{

                var contact = await _dbCommandRepository.GetById(request.Id);
                contact.Id = request.Id;
                contact.FirstName = request.FirstName;
                contact.LastName = request.LastName;
                contact.PhoneNumber = request.PhoneNumber;
                contact.Email = request.Email;
                contact.Title = request.Title;
                contact.MiddleInitial = request.MiddleInitial;
                contact.CreatedDate= DateTime.UtcNow;

                _dbCommandRepository.Update(contact);  
                return Result.Ok();
                
            }
            catch (Exception ex) {
                return Result.Fail(ex.InnerException.ToString());
            }   
        }
    }
}
