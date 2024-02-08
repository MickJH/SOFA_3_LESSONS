using Class;
using Microsoft.VisualBasic;
using System;

namespace Movies.PricingStrategy
{
    public class RegularStrategy : IPricingStrategy
    {
        public double CalculatePrice(MovieTicket ticket, int TicketCount, int ticketNumber)
        {
            if (ticket.MovieScreening.isWeekDay() && ticketNumber % 2 == 0)
            {
                return 0;
            }
            else
            {
                var discount = ticket.MovieScreening.isWeekDay() && TicketCount >= 6 ? 0.9 : 1;
                return (ticket.GetPrice() + (ticket.IsPremiumTicket() ? 3 : 0)) * discount;
            }
        }
    }
}
