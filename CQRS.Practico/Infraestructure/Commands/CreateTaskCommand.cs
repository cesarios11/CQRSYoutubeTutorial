using CQRS.Practico.Application.DTOs;
using MediatR;

namespace CQRS.Practico.Infraestructure.Commands
{
    //TODO: 'TaskItemDto' va a ser el tipo de respuesta que va a tener este comando
    //TODO: 'Title' y 'Description' son los elementos que se quiere que tenga el comando. (Que reciba o espere)
    public record CreateTaskCommand(string Title, string Description) : IRequest<TaskItemDto>;
}
