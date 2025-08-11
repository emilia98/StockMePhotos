using System.ComponentModel.DataAnnotations;
using static StockMePhotos.Data.Common.EntityConstants.Category;
using static StockMePhotos.ViewModels.ValidationMessages.Category;

namespace StockMePhotos.ViewModels.Category
{
    public class CategoryFormInputModel
    {
        [Required(ErrorMessage = NameRequiredMessage)]
        [MinLength(NameMinLength, ErrorMessage = NameMinLengthMessage)]
        [MaxLength(NameMaxLength, ErrorMessage = NameMaxLengthMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = DescriptionRequiredMessage)]
        [MinLength(DescriptionMinLength, ErrorMessage = DescriptionMinLengthMessage)]
        [MaxLength(DescriptionMaxLength, ErrorMessage = DescriptionMaxLengthMessage)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = SlugRequiredMessage)]
        [MinLength(SlugMinLength, ErrorMessage = SlugMinLengthMessage)]
        [MaxLength(SlugMaxLength, ErrorMessage = SlugMaxLengthMessage)]
        public string Slug { get; set; } = null!;
    }
}
