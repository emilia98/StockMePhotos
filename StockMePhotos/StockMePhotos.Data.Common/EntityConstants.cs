namespace StockMePhotos.Data.Common
{
    public static class EntityConstants
    {
        public static class Category
        {
            /// <summary>
            /// Category Name should be at least 2 characters long.
            /// </summary>
            public const int NameMinLength = 2;


            /// <summary>
            /// Category Name should have maximum length of 30 characters.
            /// </summary>
            public const int NameMaxLength = 30;

            /// <summary>
            /// Category Description should be at least 10 characters long.
            /// </summary>
            public const int DescriptionMinLength = 10;

            /// <summary>
            /// Category Description should have maximum length of 500 characters.
            /// </summary>
            public const int DescriptionMaxLength = 500;

            /// <summary>
            /// Category Slug should be at least 2 characters long.
            /// </summary>
            public const int SlugMinLength = 2;

            /// <summary>
            /// Category Slug should have maximum length of 30 characters.
            /// </summary>
            public const int SlugMaxLength = 30;
        }

        public static class Tag
        {
            /// <summary>
            /// Tag Name should be at least 2 characters long.
            /// </summary>
            public const int NameMinLength = 2;

            /// <summary>
            /// Tag Name should have maximum length of 30 characters.
            /// </summary>
            public const int NameMaxLength = 30;

            /// <summary>
            /// Tag Slug should be at least 2 characters long.
            /// </summary>
            public const int SlugMinlength = 2;

            /// <summary>
            /// Tag Slug should have maximum length of 30 characters.
            /// </summary>
            public const int SlugMaxLength = 30;
        }

        public static class Image
        {
            /// <summary>
            /// Image Title should be at least 1 characters long.
            /// </summary>
            public const int TitleMinLength = 1;

            /// <summary>
            /// Image Title should have maximum length of 30 characters.
            /// </summary>
            public const int TitleMaxLength = 30;

            /// <summary>
            /// Image Alt Text should be at least 2 characters long.
            /// </summary>
            public const int AltTextMinLength = 2;

            /// <summary>
            /// Image Alt Text should have maximum length of 30 characters.
            /// </summary>
            public const int AltTextMaxLength = 30;

            /// <summary>
            /// Image Extension should be at least 3 characters long.
            /// </summary>
            public const int ExtensionMinLength = 3;

            /// <summary>
            /// Image Extension should have maximum length of 4 characters.
            /// </summary>
            public const int ExtensionMaxLength = 4;

            /// <summary>
            /// Image URL should be at least 20 characters long.
            /// </summary>
            public const int URLMinLength = 20;

            /// <summary>
            /// Image URL should have maximum length of 2000 characters.
            /// </summary>
            public const int URLMaxLength = 2000;
        }
    }
}
