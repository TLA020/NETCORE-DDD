using MediatR;
using Microsoft.Extensions.Logging;
using Reservations.API.Application.Queries;
using Reservations.Domain.Models;
using Reservations.Infrastructure.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace Reservations.API.Application.Commands
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, bool>
    {
        private readonly ILogger _logger;
        private readonly ReservationsContext _dbContext;

        public CreateReservationCommandHandler(ReservationsContext dbContext, ILogger<CreateReservationCommandHandler> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(CreateReservationCommand command, CancellationToken cancellationToken)
        {
            await _dbContext.Reservations.AddAsync(command.Reservation);

            var created = await _dbContext.SaveChangesAsync() > 0;

            if (!created)
            {
                _logger.LogWarning("Could not create Reservation");
            }

            return created;
        }
    }
}
