using MediatR;

namespace CQRS.Practico.Infraestructure.Commands
{
    public record DeleteTaskCommand(int Id) : IRequest<bool>;
}
