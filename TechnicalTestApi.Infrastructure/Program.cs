using TechnicalTestApi.Infrastructure.Contexts;

namespace TechnicalTestApi.Infrastructure.Data
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("creando db si no existe...");
            SaleOrderContext contextDb = new SaleOrderContext();
            contextDb.Database.EnsureCreated();
            Console.WriteLine("Db creada correctamente.");
            Console.ReadKey();
        }
    }
}