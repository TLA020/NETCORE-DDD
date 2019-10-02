using MediatR;
using Reservations.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations.API.Application.Commands
{
    public class CreateReservationCommand : IRequest<bool>
    {
        public Reservation Reservation { get; }

        public CreateReservationCommand(Reservation reservation)
        {
            Reservation = reservation;
        }
    }
}
