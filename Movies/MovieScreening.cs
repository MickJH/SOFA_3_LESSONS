using System;
using Class;

namespace Class
{
    public class MovieScreening
    {
        private DateTime _dateAndTime;
        public double _pricePerSeat;

        public MovieScreening(Movie movie, DateTime dateAndTime, double pricePerSeat)
        {
            _dateAndTime = dateAndTime;
            _pricePerSeat = pricePerSeat;
        }

        public bool isWeekDay()
        {
            if (_dateAndTime.DayOfWeek != DayOfWeek.Sunday && _dateAndTime.DayOfWeek != DayOfWeek.Saturday)
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
            return _pricePerSeat.ToString();
        }
    }

}