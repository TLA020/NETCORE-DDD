using Reservations.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reservations.Infrastructure.Contexts;

namespace Reservations.API.Application.Queries
{
    public class ReservationQueries : IReservationQueries
    {
        private readonly ReservationsContext _context;
        public ReservationQueries(ReservationsContext context)
        {
            _context = context;
        }
        public async Task<Reservation> GetReservationByID(Guid id)
        {
            return await _context.Reservations.FindAsync(id);
        }
        public async Task<List<Reservation>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }
    }
}
