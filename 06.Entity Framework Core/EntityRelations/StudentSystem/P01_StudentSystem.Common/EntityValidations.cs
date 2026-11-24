namespace P01_StudentSystem.Common
{
    public static class EntityValidations
    {
        public static class Student
        {
            public const int NameMaxLength = 100;
            public const string NameTypeName = "NVARCHAR(100)";
            public const int PhoneNumberLength = 10;
            public const string PhoneNumberTypeName = "CHAR(10)";
        }

        public static class Course
        {
            public const int NameMaxLength = 80;
            public const string NameTypeName = "NVARCHAR(80)";
            public const string DescriptionTypeName = "NVARCHAR(MAX)";
            public const string PriceColumnType = "DECIMAL(18,2)";
        }

        public static class Homework
        {
            public const string ContentTypeName = "VARCHAR(500)";
        }

        public static class Resource
        {
            public const int NameMaxLength = 50;
            public const string NameTypeName = "NVARCHAR(50)";
            public const string UrlTypeName = "VARCHAR(2048)";
        }
    }
}
