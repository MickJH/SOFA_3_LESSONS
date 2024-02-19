using System;

namespace Class
{
    public class OrderCancelledState : IOrderState
    {
        public void Submit(Order order)
        {
            // Order already canceled
            Console.WriteLine("Order already canceled.");
        }

        public void Pay(Order order)
        {
            // Payment not possible for canceled order
            Console.WriteLine("Cannot pay for canceled order.");
        }

        public void Cancel(Order order)
        {
            // Order already canceled
            Console.WriteLine("Order already cancelled.");
        }

        public void Remind(Order order)
        {
            // No reminder needed for canceled order
            Console.WriteLine("No reminder needed for canceled order.");
        }
    }
}