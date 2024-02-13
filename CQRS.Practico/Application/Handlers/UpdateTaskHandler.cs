using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Domain;
using CQRS.Practico.Infraestructure;
using CQRS.Practico.Infraestructure.Commands;
using MediatR;

namespace CQRS.Practico.Application.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskItemDto>
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateTaskHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<TaskItemDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await this._dbContext.TaskItems.FindAsync(new object[] { request.Id }, cancellationToken);

            if (taskItem == null)
            {
                return null;
            }

            taskItem.Title = request.Title;
            taskItem.Description = request.Description;
            taskItem.IsCompleted = request.IsCompleted;

            await this._dbContext.SaveChangesAsync(cancellationToken);

            return new TaskItemDto()
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted
            };

        }
    }
}
