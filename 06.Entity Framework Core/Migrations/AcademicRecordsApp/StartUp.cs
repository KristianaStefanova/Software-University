using AcademicRecordsApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademicRecordsApp
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            /* Often used during development before initial application release */
            if (Environment.GetEnvironmentVariables().Contains("DEV"))
            {
                /* Never use with PROD database */
                AcademicRecordsDbContext context = new AcademicRecordsDbContext();
                context.Database.Migrate();
            }
               

        }
    }
}
