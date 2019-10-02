using MediatR;
using Reservations.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations.API.Application.Commands
{
    public class CreateCustomerCommand : IRequest<bool>
    {
        public Customer Customer { get; }

        public CreateCustomerCommand(Customer customer)
        {
            Customer = customer;
        }
    }
}
