using CQRS.Practico.Application.DTOs;
using MediatR;

namespace CQRS.Practico.Infraestructure.Commands
{
    public record UpdateTaskCommand(int Id, string Title, string Description, bool IsCompleted) : IRequest<TaskItemDto>;
}
