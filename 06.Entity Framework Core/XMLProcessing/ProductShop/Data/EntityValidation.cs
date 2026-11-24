using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.Data
{
    public static class EntityValidation
    {
        public static class Category
        {
            public const int NameMaxLength = 50;
        }

        public static class Product
        {
            public const int NameMaxLength = 200;
            public const string PriceColumnType = "DECIMAL(11,2)";
        }

        public static class User
        {
            public const int FirstNameMaxLength = 50;
            public const int LastNameMaxLength = 70;
        }
    }
}
