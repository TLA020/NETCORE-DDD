using MediatR;
using Microsoft.Extensions.Logging;
using Reservations.API.Application.Queries;
using Reservations.Domain.Models;
using Reservations.Infrastructure.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace Reservations.API.Application.Commands
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, bool>
    {
        private readonly ILogger _logger;
        private readonly ReservationsContext _dbContext;

        public DeleteReservationCommandHandler(ReservationsContext dbContext, ILogger<CreateReservationCommandHandler> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteReservationCommand command, CancellationToken cancellationToken)
        {
            
            Reservation reservation = await _dbContext.Reservations.FindAsync(command.Id);
            _dbContext.Reservations.Remove(reservation);

            var deleted = await _dbContext.SaveChangesAsync() > 0;
            if (!deleted)
            {
                _logger.LogWarning("Could not delete Reservation...");
            }

            return deleted;
        }
    }
}
