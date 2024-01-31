using Class;
using System;

namespace Class
{
    public class MovieTicket
    {
        public int RowNr { get; private set; }
        public int SeatNr { get; private set; }
        public bool IsPremium { get; private set; }

        public MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
        {
            this.RowNr = seatRow;
            this.SeatNr = seatNr;
            this.IsPremium = isPremiumReservation;
        }

        public bool IsPremiumTicket()
        {
            return IsPremium;
        }

        public double GetPrice()
        {
            // TODO: Implement price calculation logic
            return 0.0;
        }

        public override string ToString()
        {
            return $"Row: {RowNr}, Seat: {SeatNr}, Premium: {IsPremium}";
        }
    }
}
