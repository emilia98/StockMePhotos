namespace StockMePhotos.Data.Common
{
    public static class DataValidation
    {
        public static class Tag
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 30;
            public const int SlugMinLength = 1;
            public const int SlugMaxLength = 30;
        }

        public static class Category
        {
            public const int NameMinLength = 1;
            public const int NameMaxLength = 50;
            public const int SlugMinLength = 1;
            public const int SlugMaxLength = 50;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 150;
        }

        public static class Photo
        {
            public const int TitleMinLength = 1;
            public const int TitleMaxLength = 75;
            public const int SlugMinLength = 1;
            public const int SlugMaxLength = 20;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 500;
        }
    }
}