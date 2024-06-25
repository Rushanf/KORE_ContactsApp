using MediatR;

namespace KORE_ContactManagement.Application.Commands
{
    public record CreateContactCommand(int Id,string FirstName ,string LastName, string Email,string PhoneNumber,string Title,string MiddleInitial) : IRequest<Result>;
}
