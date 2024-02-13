using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Infraestructure;
using CQRS.Practico.Infraestructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Practico.Application.Handlers
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskItemDto>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetTaskByIdHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<TaskItemDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var taskItem = await this._dbContext.TaskItems.FindAsync(new object[] { request.Id }, cancellationToken);

            if (taskItem == null)
            {
                return null;
            }

            return new TaskItemDto 
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted
            };
        }
    }
}
