namespace Class
{
    public class PlainTextExporter : IExportFormat
    {
        public void Export(Order order)
        {
            string fileName = "order_export.txt";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"Order Number: {order.OrderNr}");
                writer.WriteLine($"Is Student Order: {order.IsStudentOrder}");
                writer.WriteLine($"Total Price: {order.price}");
                writer.WriteLine("Tickets:");

                foreach (var ticket in order.Tickets)
                {
                    writer.WriteLine(ticket.ToString());
                }
            }

            Console.WriteLine($"Exported to Plain Text successfully. File: {fileName}");
        }
    }
}


