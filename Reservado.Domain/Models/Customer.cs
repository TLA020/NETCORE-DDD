using System;
using System.Collections.Generic;
using System.Text;

namespace Reservations.Domain.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Reservations { get; set; }
        public string Remarks { get; set; }
    }
}
