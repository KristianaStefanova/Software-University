using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniORM
{
    static class ExceptionMessages
    {
        public const string NullEntityAddedMessage =
            @"Entity cannot be null.";

        public const string MapNavigationCollectionNotFound =
            @"There was an internal error while mapping navigation collections. Please make sure that your AppDbContext inherits from the MiniORM DBContext.";

        public static string PrimaryKeyNullErrorMessage =
               @"The primary keys cannot have null values!";

        public static string InvalidEntitiesInDbSetMessage =
            @"{0} Invalid Entities Found in {1}!";

        public static string NoTableNameFound =
            @"Could not find a valid table name for DbSet {0}!";

        public static string NullDbSetMessage =
            @"Fatal error occurred! The DbSet {0} is null!";

        public static string InvalidNavigationPropertyName =
            @"Foreign key {0} references navigation property with name {1} which does not exist!";

        public static string NavPropertyWithoutDbSetMessage =
            @"DbSet could not be found for navigation property {0} of type {1}!";

        public static string TransactionRollbackMessage =
            @"Performing Rollback due to Exception!!!";

        public static string TransactionExceptionMessage =
            @"The SQL Transaction failed due to unexpected error!";
    }
}
