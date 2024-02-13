using CQRS.Practico.Application.DTOs;
using MediatR;

namespace CQRS.Practico.Infraestructure.Queries
{
    public record GetTaskByIdQuery(int Id) : IRequest<TaskItemDto>;    
}
