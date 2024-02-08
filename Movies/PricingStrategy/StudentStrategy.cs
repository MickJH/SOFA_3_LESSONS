using Class;

namespace Movies.PricingStrategy
{
    public class StudentStrategy : IPricingStrategy
    {
        public double CalculatePrice(MovieTicket ticket, int TicketCount, int ticketNumber)
        {
            if (ticketNumber % 2 == 0)
            {
                return 0;
            }
            else
            {
                return ticket.GetPrice() + (ticket.IsPremiumTicket() ? 2 : 0);
            }
        }
    }
}
