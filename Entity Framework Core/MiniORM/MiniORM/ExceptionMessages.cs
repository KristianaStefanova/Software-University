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
            "Entity cannot be null.";

        public const string PopulateDbSetNotFoundMessage = 
            "There was an internal error while populating the DbSet. Please make sure that your AppDbContext inherits from the MiniORM DBContext.";

        public const string NullDbSetMessage = 
            "There was an internal error while populating the DbSet.";

        public const string MapRelationsNotFoundMessage = 
            "There was an internal error while mapping relations. Please make sure that your AppDbContext inherits from the MiniORM DBContext.";

        public const string MapNavigationCollectionNotFound = 
            "There was an internal error while mapping navigation collections. Please make sure that your AppDbContext inherits from the MiniORM DBContext.";
    }
}
