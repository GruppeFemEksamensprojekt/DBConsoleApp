using System;
using System.Collections.Generic;
using System.Text;

namespace ModelKlasser
{
    public class Booking
    {
        public int BookingId { get; set; }

        public Room Room { get; set; }

        public Guest Guest { get; set; }

        public DateTime FraDato { get; set; }

        public DateTime TilDato { get; set; }
    }
}
