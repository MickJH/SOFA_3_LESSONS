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
        public double price { get; private set; }
        public IOrderState State { get; set; }

        public Order(int orderNr, bool isStudentOrder, IOrderState initialState)
        {
            this.OrderNr = orderNr;
            this.IsStudentOrder = isStudentOrder;
            this.Tickets = new List<MovieTicket>();

            // Check if the initial state is one of the allowed states
            if (initialState.GetType() != typeof(OrderCreatedState))
            {
                throw new ArgumentException("Invalid initial state");
            }

            this.State = initialState;
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

        public void Submit()
        {
            State.Submit(this);
        }

        public void Pay()
        {
            State.Pay(this);
        }

        public void Cancel()
        {
            State.Cancel(this);
        }

        public void Remind()
        {
            State.Remind(this);
        }

        public void export(TicketExportFormat exportFormat)
        {
            exportFormat.Export(this);
        }
    }
}
