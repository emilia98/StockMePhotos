using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMePhotos.ViewModels
{
    public static class ValidationMessages
    {
        public static class Category
        {
            public const string NameRequiredMessage = "The category name is required.";
            public const string NameMinLengthMessage = "The category name should be at least 2 characters long.";
            public const string NameMaxLengthMessage = "The category name should have maximum length of 30 characters.";

            public const string DescriptionRequiredMessage = "The category description is required.";
            public const string DescriptionMinLengthMessage = "The category description should be at least 10 characters long.";
            public const string DescriptionMaxLengthMessage = "The category description should have maximum length of 500 characters.";

            public const string SlugRequiredMessage = "The category slug is required.";
            public const string SlugMinLengthMessage = "The category slug should be at least 2 characters long.";
            public const string SlugMaxLengthMessage = "The category slug should have maximum length of 30 characters.";
        }
    }
}
