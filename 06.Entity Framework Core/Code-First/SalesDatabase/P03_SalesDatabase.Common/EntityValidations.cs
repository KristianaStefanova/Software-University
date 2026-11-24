namespace P03_SalesDatabase.Common
{
    public static class EntityValidations
    {
        public static class Store
        {
            public const int NameMaxLength = 80;
        }

        public static class Product
        {
            public const int NameMaxLength = 50;
            public const string PriceType = "DECIMAL(16,2)";
            public const string QuantityType = "DECIMAL(16,3)";
        }

        public static class Customer
        {
            public const int NameMaxLength = 100;
            public const int EmailMaxLength = 80;
            public const int CreditCardNumberMaxLength = 40;
        }
    }
}
