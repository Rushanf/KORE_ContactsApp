using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KORE_ContactManagement.Application.Commands
{
    public record DeleteContactCommand(int Id) : IRequest<Result>;
}
