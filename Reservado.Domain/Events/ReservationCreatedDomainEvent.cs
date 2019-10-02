using System;
using System.Collections.Generic;
using System.Text;
//using MediatR;

namespace Reservations.Domain.Events
{
   public class ReservationCreatedDomainEvent
    {
        public Guid ReservationId { get; set; } //: INotification

        public ReservationCreatedDomainEvent(Guid reservationId)
        {
            ReservationId = reservationId;
        }
    }
}
