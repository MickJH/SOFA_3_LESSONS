using Class;
using System;

namespace Class
{

    public class MovieTicket
    {
        private int _rowNr;
        private int _seatNr;
        private bool _isPremium;

        public MovieTicket(MovieScreening movieScreening, bool isPremiumReservation, int seatRow, int seatNr)
        {
            this._rowNr = seatRow;
            this._seatNr = seatNr;
            this._isPremium = isPremiumReservation;
        }

        public bool isPremiumTicket()
        {
            //TODO
            return true;
        }

        public double getPrice()
        {
            //TODO
            return 0.0;
        }

        public string toString()
        {
            //TODO
            return null;
        }
    }
}