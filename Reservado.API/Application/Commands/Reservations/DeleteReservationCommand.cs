using MediatR;
using Reservations.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations.API.Application.Commands
{
    public class DeleteReservationCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public DeleteReservationCommand(Guid id)
        {
            Id = id;
        }
    }
}
