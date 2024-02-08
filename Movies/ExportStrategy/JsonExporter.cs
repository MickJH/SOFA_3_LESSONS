using System.Text.Json;

namespace Class
{
    public class JsonExporter : IExportFormat
    {
        public void Export(Order order)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            string jsonExport = JsonSerializer.Serialize(order, options);

            File.WriteAllText("order_export.json", jsonExport);
            Console.WriteLine("Exported to JSON successfully.");
        }
    }
}


