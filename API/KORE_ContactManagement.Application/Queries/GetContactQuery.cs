using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KORE_ContactManagement.Application.Queries
{
    public record GetContactQuery(int Id) : IRequest<ContactModel>;
}
