using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Infraestructure;
using CQRS.Practico.Infraestructure.Commands;
using CQRS.Practico.Infraestructure.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Practico.Application.Handlers
{
    public class GetAllTaskHandler : IRequestHandler<GetAllTaskQuery, IEnumerable<TaskItemDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetAllTaskHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<IEnumerable<TaskItemDto>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
        {
            var tasks = await this._dbContext.TaskItems.ToListAsync(cancellationToken);

            return tasks.Select(task => new TaskItemDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted
            });
        }
    }
}
