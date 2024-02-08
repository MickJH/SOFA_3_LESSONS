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
            StrategyFactory pricingStrategyFactory = new StrategyFactory(this.IsStudentOrder);
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
    }
}
