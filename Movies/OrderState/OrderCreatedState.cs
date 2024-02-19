using System;

namespace Class
{
    public class OrderCreatedState : IOrderState
    {
        public void Submit(Order order)
        {
            // Transition to submitted state
            order.State = new OrderSubmittedState();
        }

        public void Pay(Order order)
        {
            // Payment not possible in this state
            Console.WriteLine("Cannot pay for the order before submitting.");
        }

        public void Cancel(Order order)
        {
            // Cancel the order
            Console.WriteLine("Order cancelled.");
            order.State = new OrderCancelledState();
        }

        public void Remind(Order order)
        {
            // No reminder needed in this state
            Console.WriteLine("No reminder needed for the order.");
        }
    }
}