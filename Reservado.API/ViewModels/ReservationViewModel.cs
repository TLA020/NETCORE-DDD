using Reservations.Domain.Models;
using System;

namespace Reservations.API.ViewModels
{
    public class ReservationViewModel
    {
        public Guid Id { get; set; }
        public Customer Customer { get; set; }
        public int Amount { get; set; }
        public string Remark { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Table { get; set; }
    }
}
