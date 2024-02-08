using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Class
{
    public class Order
    {
        public int OrderNr { get; private set; }
        public bool IsStudentOrder { get; private set; }
        public List<MovieTicket> Tickets { get; private set; }
        public double price { get; private set; }

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
            price = 0.0;

            for (int i = 1; i <= Tickets.Count; i++)
            {
                if (i % 2 == 0 && (IsStudentOrder || (Tickets.First().MovieScreening.isWeekDay())))
                {
                    price += 0;
                }
                else if (Tickets.ElementAt(i - 1).IsPremiumTicket())
                {
                    price += Tickets.ElementAt(i - 1).GetPrice();
                    price += IsStudentOrder ? 2 : 3;
                }
                else
                {
                    price += Tickets.ElementAt(i - 1).GetPrice();
                }
            }

            if (!IsStudentOrder && Tickets.Count >= 6)
            {
                price *= 0.9;
            }

            return price;
        }

        public void Export(IExportFormat exportFormat)
        {
            exportFormat.Export(this);
        }

    }
}
