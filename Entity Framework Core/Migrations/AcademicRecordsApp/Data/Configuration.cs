using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace AcademicRecordsApp.Data
{
    internal static class Configuration
    {
        private const string DefaultConnectionString = 
            "Server=.;Database=AcademicRecordsDB;Trusted_Connection=True;Encrypt=False;";
        internal static string GetConnectionString()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddUserSecrets<StartUp>()
                .Build();

            IConfigurationProvider secretsProvider = config.Providers.First();
            bool success = secretsProvider
                .TryGet("DafaultConnection_NoEncrypt", out string? connectionString);

           if(success && !string.IsNullOrEmpty(connectionString))
           {
                return connectionString;
           }

           return DefaultConnectionString;
        }
    }

}
