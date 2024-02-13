using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Domain;
using CQRS.Practico.Infraestructure;
using CQRS.Practico.Infraestructure.Commands;
using MediatR;

namespace CQRS.Practico.Application.Handlers
{
    //TODO: El tipo de comando para este request es 'CreateTaskCommand' y la respuesta va a ser un 'TaskItemDto'
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, TaskItemDto>
    {
        private readonly ApplicationDbContext _dbContext;
        public CreateTaskHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        //TODO: El método handle va a manejar el request 'CreateTaskCommand'.
        public async Task<TaskItemDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = new TaskItem() 
            {
                Title = request.Title,
                Description = request.Description,
            };

            this._dbContext.TaskItems.Add(taskItem);

            await this._dbContext.SaveChangesAsync(cancellationToken);

            return new TaskItemDto() 
            {
                Id= taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted
            };
        }
    }
}
