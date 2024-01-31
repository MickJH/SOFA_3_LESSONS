using System;
using Class;

namespace Class
{
    public class Order
    {
        private int _orderNr;
        private bool _isStudentOrder;

        public Order(int orderNr, bool isStudentOrder)
        {
            this._orderNr = orderNr;
            this._isStudentOrder = isStudentOrder;
        }

        public int getOrderNr()
        {
            //TODO
            return 0;
        }

        public void addSeatReservation(MovieTicket ticket)
        {
            //TODO
        }

        public double calculatePrice()
        {
            //TODO
            return 0.0;
        }

        public void export(TicketExportFormat exportFormat)
        {
            //TODO
        }
    }
}