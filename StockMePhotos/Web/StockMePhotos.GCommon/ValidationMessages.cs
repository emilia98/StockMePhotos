namespace StockMePhotos.GCommon
{
    public static class ValidationMessages
    {
        public static class Tag
        {
            public const string NameRequired = "Name is required.";
            public const string NameMinLength = "Name should be at least {0} characters long.";
            public const string NameMaxLength = "Name should have max length of {0} characters.";
        }

        public static class Category
        {
            public const string NameRequired = "Name is required.";
            public const string NameMinLength = "Name should be at least {0} characters long.";
            public const string NameMaxLength = "Name should have max length of {0} characters.";
            public const string DescriptionRequired = "Description is required.";
            public const string DescriptionMinLength = "Description should be at least {0} characters long.";
            public const string DescriptionMaxLength = "Description should have max length of {0} characters.";
        }
    }
}