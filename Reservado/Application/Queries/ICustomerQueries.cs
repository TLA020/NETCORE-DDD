using Reservations.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations.API.Application.Queries
{
   public interface ICustomerQueries
    {
        Task<Customer> GetCustomerById(Guid id);
        Task <List<Customer>> GetCustomers();
    }
}
