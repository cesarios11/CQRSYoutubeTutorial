using CQRS.Practico.Application.DTOs;
using CQRS.Practico.Infraestructure;
using CQRS.Practico.Infraestructure.Commands;
using MediatR;

namespace CQRS.Practico.Application.Handlers
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteTaskHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await this._dbContext.TaskItems.FindAsync(new object[] { request.Id }, cancellationToken);

            if (taskItem == null)
            {
                return false;
            }

            this._dbContext.TaskItems.Remove(taskItem);
            await this._dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
