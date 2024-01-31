using System;

namespace Class
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a movie
            Movie movie = new Movie("Now you see me");

            // Create a movie screening
            MovieScreening screening = new MovieScreening(movie, DateTime.Now, 10.0);

            // Create movie tickets
            MovieTicket ticket1 = new MovieTicket(screening, false, 1, 1);
            MovieTicket ticket2 = new MovieTicket(screening, true, 2, 3);

            // Create an order
            Order order = new Order(1, true);
            order.addSeatReservation(ticket1);
            order.addSeatReservation(ticket2);

            // Export the order to plain text
            Console.WriteLine("Exporting Order to Plain Text:");
            order.export(TicketExportFormat.PLAINTEXT);
            Console.WriteLine();

            // Export the order to JSON
            Console.WriteLine("Exporting Order to JSON:");
            order.export(TicketExportFormat.JSON);
        }
    }
}
