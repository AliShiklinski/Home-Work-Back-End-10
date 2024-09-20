using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Core.Entities
{
    public class SeatReservation : BaseEntity
    {
 public string SeatNumber { get; set; }
        public bool IsBooked { get; set; }
        public int ShowtimeId { get; set; }
        public ShowTime ShowTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Reservation Reservation { get; set; }
    }
}
