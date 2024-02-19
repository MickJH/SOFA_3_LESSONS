using System;

namespace Class
{
    public class OrderSubmittedState : IOrderState
    {
        public void Submit(Order order)
        {
            // Already submitted
            Console.WriteLine("Order already submitted.");
        }

        public void Pay(Order order)
        {
            // Transition to paid state
            order.State = new OrderPaidState();
        }

        public void Cancel(Order order)
        {
            // Cancel the order
            Console.WriteLine("Order cancelled.");
            order.State = new OrderCancelledState();
        }

        public void Remind(Order order)
        {
            // Send reminder
            Console.WriteLine("Reminder sent.");
        }
    }
}