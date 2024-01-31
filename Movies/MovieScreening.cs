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

        public bool isWeekDay()
        {
            if (this._dateAndTime.DayOfWeek != DayOfWeek.Sunday && this._dateAndTime.DayOfWeek != DayOfWeek.Saturday)
            {
                return true;
            }

            return false;
        }

        public double getPricePerSeat()
        {
            return this._pricePerSeat;
        }

        public string toString()
        {
            //TODO
            return null;
        }
    }

}