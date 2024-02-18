using System;

namespace Class
{
    public class OrderPaidState : IOrderState
    {
        public void Submit(Order order)
        {
            // Payment done, no further action
            Console.WriteLine("Order already paid for.");
        }

        public void Pay(Order order)
        {
            // Already paid
            Console.WriteLine("Order already paid for.");
        }

        public void Cancel(Order order)
        {
            // Cancel the order
            Console.WriteLine("Order cannot be cancelled if you already paid.");
        }

        public void Remind(Order order)
        {
            // No reminder needed in this state
            Console.WriteLine("No reminder needed for the order.");
        }
    }
}