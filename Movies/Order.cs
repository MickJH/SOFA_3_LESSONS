using Movies.PricingStrategy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text.Json;

namespace Class
{
    public class Order
    {
        public int OrderNr { get; private set; }
        public bool IsStudentOrder { get; private set; }
        public List<MovieTicket> Tickets { get; private set; }
        public double orderPrice { get; private set; }

        public Order(int orderNr, bool isStudentOrder)
        {
            this.OrderNr = orderNr;
            this.IsStudentOrder = isStudentOrder;
            this.Tickets = new List<MovieTicket>();
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            Tickets.Add(ticket);
        }

        public double CalculatePrice()
        {
            StrategyFactory pricingStrategyFactory  = new StrategyFactory(this.IsStudentOrder);
            IPricingStrategy pricingStrategy = pricingStrategyFactory.GetPricingStrategy();

            orderPrice = 0.0;

            for (int i = 0; i < Tickets.Count; i++)
            {
                var ticketprice = pricingStrategy.CalculatePrice(Tickets.ElementAt(i), Tickets.Count, i + 1);
                orderPrice += ticketprice;
            }

            return orderPrice;
        }

        public void Export(IExportFormat exportFormat)
        {
            exportFormat.Export(this);
        }

<<<<<<< HEAD
=======
        private void exportToPlainText()
        {
            string fileName = "order_export.txt";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"Order Number: {OrderNr}");
                writer.WriteLine($"Is Student Order: {IsStudentOrder}");
                writer.WriteLine($"Total Price: {orderPrice}");
                writer.WriteLine("Tickets:");

                foreach (var ticket in Tickets)
                {
                    writer.WriteLine(ticket.ToString());
                }
            }

            Console.WriteLine($"Exported to Plain Text successfully. File: {fileName}");
        }

        private void exportToJSON()
        {
            // Use System.Text.Json for JSON serialization
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            string jsonExport = JsonSerializer.Serialize(this, options);

            File.WriteAllText("order_export.json", jsonExport);
            Console.WriteLine("Exported to JSON successfully.");
        }
>>>>>>> 0e99d743bfd77d9b664de053c908e41afabb84bc
    }
}
