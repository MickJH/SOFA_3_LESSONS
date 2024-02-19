using Class;
using System;

namespace MoviesTests
{
    public class StatesTests
    {
        [Fact]
        public void OrderCreatedStateShouldChangeToOrderSubmitState_()
        {
            // Arrange
            Order order = new Order(1, true, new OrderCreatedState());

            // Act
            order.Submit();

            // Assert
            Assert.IsType<OrderSubmittedState>(order.State);
        }

        [Fact]
        public void OrderCreatedStateShouldChangeToOrderCancelledState()
        {
            // Arrange
            Order order = new Order(1, true, new OrderCreatedState());

            // Act
            order.Cancel();

            // Assert
            Assert.IsType<OrderCancelledState>(order.State);
        }

        [Fact]
        public void OrderSubmittedStateShouldChangeToOrderPaidState()
        {
            // Arrange
            Order order = new Order(1, true, new OrderCreatedState());
            order.Submit(); // Transition to Submitted state

            // Act
            order.Pay();

            // Assert
            Assert.IsType<OrderPaidState>(order.State);
        }

        [Fact]
        public void OrderSubmittedStateShouldChangeToOrderCancelledState()
        {
            // Arrange
            Order order = new Order(1, true, new OrderCreatedState());
            order.Submit(); // Transition to Submitted state

            // Act
            order.Cancel();

            // Assert
            Assert.IsType<OrderCancelledState>(order.State);
        }
    }
}