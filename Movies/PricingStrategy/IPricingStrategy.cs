using Class;

namespace Movies.PricingStrategy
{
    public interface IPricingStrategy
    {
        public double CalculatePrice(MovieTicket ticket, int TicketCount, int ticketNumber);
    }
}
