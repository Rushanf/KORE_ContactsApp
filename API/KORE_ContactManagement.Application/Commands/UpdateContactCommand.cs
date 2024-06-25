﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KORE_ContactManagement.Application.Commands
{
    public record UpdateContactCommand(int Id,string FirstName ,string LastName, string Email,string PhoneNumber,string Title,string MiddleInitial) : IRequest<Result>;
}
