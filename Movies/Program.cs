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
            MovieScreening screening = new(movie, DateTime.Now, 10.0);

            // Create movie tickets
            MovieTicket ticket1 = new(screening, false, 1, 1);
            MovieTicket ticket2 = new(screening, false, 2, 3);
            MovieTicket ticket3 = new(screening, false, 3, 4);
            MovieTicket ticket4 = new(screening, false, 4, 5);
            MovieTicket ticket5 = new(screening, false, 5, 6);
            //MovieTicket ticket6 = new(screening, false, 6, 7);

            // Create an order
            Order order = new(1, true);
            order.addSeatReservation(ticket1);
            order.addSeatReservation(ticket2);            
            order.addSeatReservation(ticket3);
            order.addSeatReservation(ticket4);
            order.addSeatReservation(ticket5);
            //order.addSeatReservation(ticket6);

            // Calculate and display the price
            double totalPrice = order.CalculatePrice();
            Console.WriteLine($"Total Price: {totalPrice}");

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
