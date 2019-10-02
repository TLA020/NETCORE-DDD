using MediatR;
using Microsoft.Extensions.Logging;
using Reservations.API.Application.Queries;
using Reservations.Domain.Models;
using Reservations.Infrastructure.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace Reservations.API.Application.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly ILogger _logger;
        private readonly ReservationsContext _dbContext;

        public CreateCustomerCommandHandler(ReservationsContext dbContext, ILogger<CreateCustomerCommandHandler> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            await _dbContext.Customers.AddAsync(command.Customer);

            var created = await _dbContext.SaveChangesAsync() > 0;

            if (!created)
            {
                _logger.LogWarning("Could not create Customer");
            }

            return created;
        }
    }
}
