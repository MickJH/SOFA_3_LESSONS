using System;

namespace Class
{
    public class Movie
    {
        private string _title;

        public Movie(string title)
        {
            this._title = title;
        }

        public void addScreening(MovieScreening screening)
        {
            //TODO
        }

        public string toString()
        {
            return _title;
        }
    }
}