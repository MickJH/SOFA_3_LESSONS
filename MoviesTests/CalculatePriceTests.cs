using Class;

namespace MoviesTests
{
    public class CalculatePriceTest
    {
        // 1-2-4-8 --> student
        [Fact]
        public void StudentSecondFreeTicketNormal()
        {
            // Arrange
            Movie movie = new("Now you see me");

            MovieScreening screening = new(movie, DateTime.Now, 10.0);

            MovieTicket ticket1 = new(screening, false, 1, 1);
            MovieTicket ticket2 = new(screening, false, 2, 3);
            MovieTicket ticket3 = new(screening, false, 3, 4);
            MovieTicket ticket4 = new(screening, false, 4, 5);

            Order order = new(1, true);
            order.addSeatReservation(ticket1);
            order.addSeatReservation(ticket2);
            order.addSeatReservation(ticket3);
            order.addSeatReservation(ticket4);

            // Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(20.0, result);
        }

        // 1-2-4-8 --> non-student
        [Fact]
        public void WeekDaySecondFreeTicketNormal()
        {
            // Arrange
            Movie movie = new("Now you see me");

            DateTime screeningDate = new(2024, 2, 7); // February 7, 2024, Wednesday
            MovieScreening screening = new(movie, screeningDate, 10.0);

            MovieTicket ticket1 = new(screening, false, 1, 1);
            MovieTicket ticket2 = new(screening, false, 2, 3);
            MovieTicket ticket3 = new(screening, false, 3, 4);
            MovieTicket ticket4 = new(screening, false, 4, 5);

            Order order = new(1, false);  // Create non-student order
            order.addSeatReservation(ticket1);
            order.addSeatReservation(ticket2);
            order.addSeatReservation(ticket3);
            order.addSeatReservation(ticket4);

            // Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(20.0, result);
        }

        // 1-2-4-9
        [Fact]
        public void WeekDaySecondFreeTicketPremium()
        {
            // Arrange
            Movie movie = new("Now you see me");

            DateTime screeningDate = new(2024, 2, 7); // February 7, 2024, Wednesday
            MovieScreening screening = new(movie, screeningDate, 10.0);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 2, 3);
            MovieTicket ticket3 = new(screening, true, 3, 4);
            MovieTicket ticket4 = new(screening, true, 4, 5);
            MovieTicket ticket5 = new(screening, true, 5, 6);
            MovieTicket ticket6 = new(screening, true, 6, 7);

            Order order = new(1, false);  // Create non-student order
            order.addSeatReservation(ticket1);
            order.addSeatReservation(ticket2);
            order.addSeatReservation(ticket3);
            order.addSeatReservation(ticket4);
            order.addSeatReservation(ticket5);
            order.addSeatReservation(ticket6);

            // Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(35.1, result);
        }

        // 1-2-3-6-8
        [Fact]
        public void NoDiscountsPremiumTickets()
        {
            // Arrange
            Movie movie = new("Now you see me");

            DateTime screeningDate = new(2024, 2, 4); // February 4, 2024, Sunday
            MovieScreening screening = new(movie, screeningDate, 10.0);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 2, 3);
            MovieTicket ticket3 = new(screening, true, 3, 4);
            MovieTicket ticket4 = new(screening, true, 4, 5);

            Order order = new(1, false);  // Create non-student order
            order.addSeatReservation(ticket1);
            order.addSeatReservation(ticket2);
            order.addSeatReservation(ticket3);
            order.addSeatReservation(ticket4);

            // Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(52.0, result);
        }

        // 1-2-3-6-9
        [Fact]
        public void GroupDiscountPremiumTickets()
        {
            // Arrange
            Movie movie = new("Now you see me");

            DateTime screeningDate = new(2024, 2, 4); // February 4, 2024, Sunday
            MovieScreening screening = new(movie, screeningDate, 10.0);

            MovieTicket ticket1 = new(screening, true, 1, 1);
            MovieTicket ticket2 = new(screening, true, 2, 3);
            MovieTicket ticket3 = new(screening, true, 3, 4);
            MovieTicket ticket4 = new(screening, true, 4, 5);
            MovieTicket ticket5 = new(screening, true, 5, 6);
            MovieTicket ticket6 = new(screening, true, 6, 7);

            Order order = new(1, false);  // Create non-student order
            order.addSeatReservation(ticket1);
            order.addSeatReservation(ticket2);
            order.addSeatReservation(ticket3);
            order.addSeatReservation(ticket4);
            order.addSeatReservation(ticket5);
            order.addSeatReservation(ticket6);

            // Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(70.2, result);
        }

        // 1-2-3-5-7-8
        [Fact]
        public void NoDiscountsNormalTickets()
        {
            // Arrange
            Movie movie = new("Now you see me");

            DateTime screeningDate = new(2024, 2, 4); // February 4, 2024, Sunday
            MovieScreening screening = new(movie, screeningDate, 10.0);

            MovieTicket ticket1 = new(screening, false, 1, 1);
            MovieTicket ticket2 = new(screening, false, 2, 3);
            MovieTicket ticket3 = new(screening, false, 3, 4);
            MovieTicket ticket4 = new(screening, false, 4, 5);

            Order order = new(1, false);  // Create non-student order
            order.addSeatReservation(ticket1);
            order.addSeatReservation(ticket2);
            order.addSeatReservation(ticket3);
            order.addSeatReservation(ticket4);

            // Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(40.0, result);
        }

        // 1-2-3-5-7-9
        [Fact]
        public void GroupDiscountNormalTickets()
        {
            // Arrange
            Movie movie = new("Now you see me");

            DateTime screeningDate = new(2024, 2, 4); // February 4, 2024, Sunday
            MovieScreening screening = new(movie, screeningDate, 10.0);

            MovieTicket ticket1 = new(screening, false, 1, 1);
            MovieTicket ticket2 = new(screening, false, 2, 3);
            MovieTicket ticket3 = new(screening, false, 3, 4);
            MovieTicket ticket4 = new(screening, false, 4, 5);
            MovieTicket ticket5 = new(screening, false, 5, 6);
            MovieTicket ticket6 = new(screening, false, 6, 7);

            Order order = new(1, false);  // Create non-student order
            order.addSeatReservation(ticket1);
            order.addSeatReservation(ticket2);
            order.addSeatReservation(ticket3);
            order.addSeatReservation(ticket4);
            order.addSeatReservation(ticket5);
            order.addSeatReservation(ticket6);

            // Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(54.0, result);
        }

        // 1-2-3-5-7-8
        [Fact]
        public void NoGroupDiscountStudentNormalTickets()
        {
            // Arrange
            Movie movie = new("Now you see me");

            DateTime screeningDate = new(2024, 2, 4); // February 4, 2024, Sunday
            MovieScreening screening = new(movie, screeningDate, 10.0);

            MovieTicket ticket1 = new(screening, false, 1, 1);
            MovieTicket ticket2 = new(screening, false, 2, 3);
            MovieTicket ticket3 = new(screening, false, 3, 4);
            MovieTicket ticket4 = new(screening, false, 4, 5);
            MovieTicket ticket5 = new(screening, false, 5, 6);
            MovieTicket ticket6 = new(screening, false, 6, 7);

            Order order = new(1, true);  // Create student order, students get no group discount
            order.addSeatReservation(ticket1);
            order.addSeatReservation(ticket2);
            order.addSeatReservation(ticket3);
            order.addSeatReservation(ticket4);
            order.addSeatReservation(ticket5);
            order.addSeatReservation(ticket6);

            // Act
            var result = order.CalculatePrice();

            // Assert
            Assert.Equal(30.0, result);
        }
    }
}