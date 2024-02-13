using CQRS.Practico.Application.DTOs;
using MediatR;

namespace CQRS.Practico.Infraestructure.Queries
{
    public record GetAllTaskQuery : IRequest<IEnumerable<TaskItemDto>>;
}
