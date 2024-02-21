using Movies.Observer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Class
{
    public class Order : INotificationSubject
    {
        public int OrderNr { get; private set; }
        public bool IsStudentOrder { get; private set; }
        public List<MovieTicket> Tickets { get; private set; }
        public double price { get; private set; }
        public IOrderState State { get; set; }
        private readonly List<INotificationObserver> _notificationObservers;

        public Order(int orderNr, bool isStudentOrder, IOrderState initialState)
        {
            OrderNr = orderNr;
            IsStudentOrder = isStudentOrder;
            Tickets = new List<MovieTicket>();
            _notificationObservers = new List<INotificationObserver>();

            // Check if the initial state is one of the allowed states
            if (initialState.GetType() != typeof(OrderCreatedState))
            {
                throw new ArgumentException("Invalid initial state");
            }

            State = initialState;
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

        public void Submit()
        {
            NotifyObservers("Order submitted.");
            State.Submit(this);
        }

        public void Pay()
        {
            NotifyObservers("Order paid.");
            State.Pay(this);
        }

        public void Cancel()
        {
            NotifyObservers("Order cancelled.");
            State.Cancel(this);
        }

        public void Remind()
        {
            NotifyObservers("Open order is waiting for action.");
            State.Remind(this);
        }

        public void export(TicketExportFormat exportFormat)
        {
            switch (exportFormat)
            {
                case TicketExportFormat.PLAINTEXT:
                    exportToPlainText();
                    break;
                case TicketExportFormat.JSON:
                    exportToJSON();
                    break;
                default:
                    Console.WriteLine("Invalid export format");
                    break;
            }
        }

        private void exportToPlainText()
        {
            string fileName = "order_export.txt";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"Order Number: {OrderNr}");
                writer.WriteLine($"Is Student Order: {IsStudentOrder}");
                writer.WriteLine($"Total Price: {price}");
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

        public void RegisterObserver(INotificationObserver observer)
        {
            _notificationObservers.Add(observer);
        }

        public void RemoveObserver(INotificationObserver observer)
        {
            int i = _notificationObservers.IndexOf(observer);
            _notificationObservers.RemoveAt(i);
        }

        public void NotifyObservers(string message)
        {
            for (int i = 0; i < _notificationObservers.Count; i++)
            {
                INotificationObserver observer = _notificationObservers.ElementAt(i);
                observer.Update(message);
            }
        }
    }
}
