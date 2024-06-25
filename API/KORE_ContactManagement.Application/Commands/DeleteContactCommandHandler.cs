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
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Result>
    {
        IDbCommandRepository<Contact> _dbCommandRepository;

        public DeleteContactCommandHandler(IDbCommandRepository<Contact> dbCommandRepository)
        {
            _dbCommandRepository = dbCommandRepository;
        }
        public async Task<Result> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        { 
            try{
                _dbCommandRepository.Delete(request.Id);  
                return Result.Ok();
                
            }
            catch (Exception ex) {
                return Result.Fail(ex.InnerException.ToString());
            }   
        }
    }
}
