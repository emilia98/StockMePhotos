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
    }
}
