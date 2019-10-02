using Reservations.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations.API.Application.Queries
{
   public interface IReservationQueries
    {
        Task<Reservation> GetReservationByID(Guid id);
        Task <List<Reservation>> GetReservations();

    }
}
