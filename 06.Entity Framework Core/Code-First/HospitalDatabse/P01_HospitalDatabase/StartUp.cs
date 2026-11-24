using Microsoft.EntityFrameworkCore.Query.Internal;
using P01_HospitalDatabase.Data;

namespace P01_HospitalDatabase
{
    class StartUp
    {
        static void Main(string[] args)
        {
			try
			{
                using HospitalContext context = new HospitalContext();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Console.WriteLine("Database created successfully!");
            }
			catch (Exception e)
			{
                Console.WriteLine(e.Message);
				throw;
			}
        }
    }
}
