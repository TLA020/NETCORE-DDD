using Reservations.Domain.Models;
using System;

namespace Reservations.API.ViewModels
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Reservations { get; set; }
        public string Remarks { get; set; }
    }
}
