using System;
using Class;

namespace Class
{
    public class MovieScreening
    {
        private DateTime _dateAndTime;
        private double _pricePerSeat;

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            this._dateAndTime = dateAndTime;
            this._pricePerSeat = pricePerSeat;
        }

        public double getPricePerSeat()
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