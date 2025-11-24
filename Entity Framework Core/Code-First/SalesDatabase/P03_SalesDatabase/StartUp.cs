using P03_SalesDatabase.Data;

namespace P03_SalesDatabase
{
    public class StartUp
    {
        static void Main(string[] args)
        {
			try
			{
                using SalesContext context = new SalesContext();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Console.WriteLine("Database created successfully.");
            }
			catch (Exception e)
			{
                Console.WriteLine(e.Message);
				throw;
			}
        }
    }
}
