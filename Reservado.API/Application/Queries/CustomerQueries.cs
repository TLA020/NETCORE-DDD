using Reservations.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reservations.Infrastructure.Contexts;

namespace Reservations.API.Application.Queries
{
    public class CustomerQueries : ICustomerQueries
    {
        private readonly ReservationsContext _context;
        public CustomerQueries(ReservationsContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }
    }
}
