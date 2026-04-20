namespace StockMePhotos.GCommon
{
    public class ValidationMessages
    {
        public static class Tag
        {
            public const string NameRequired = "Name is required.";
            public const string NameMinLength = "Name should be at least {0} characters long.";
            public const string NameMaxLength = "Name should have max length of {0} characters.";

            public const string SlugRequired = "Slug is required.";
            public const string SlugMinLength = "Slug should be at least {0} characters long.";
            public const string SlugMaxLength = "Slug should have max length of {0} characters.";
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

        public static class Photo
        {
            public const string TitleRequired = "Title is required.";
            public const string TitleMinLength = "Title should be at least {1} characters long.";
            public const string TitleMaxLength = "Title should have max length of {1} characters.";
            public const string SlugRequired = "Slug is required.";
            public const string SlugMinLength = "Slug should be at least {1} characters long.";
            public const string SlugMaxLength = "Slug should have max length of {1} characters.";
            public const string DescriptionRequired = "Description is required.";
            public const string DescriptionMinLength = "Description should be at least {1} characters long.";
            public const string DescriptionMaxLength = "Description should have max length of {1} characters.";
            public const string CategoryRequired = "Category is required.";
            public const string CategoryNotFound = "The selected category is not found.";
            public const string ImageRequired = "The image is required.";
        }

        public static class Image
        {
            public const string ImageRequired = "The image is required.";
            public const string ImageSizeExceeded = "The image shouldn't exceed {0}MB!";
            public const string ImageAllowedExtensions = "The allowed file extensions are {0}!";
            public const string InvalidImage = "The image is invalid!";
            public const string ImageUnreadble = "The file cannot be read!";
        }
    }
}
