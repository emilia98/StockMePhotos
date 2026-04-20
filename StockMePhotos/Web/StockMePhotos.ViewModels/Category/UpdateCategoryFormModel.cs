using System.ComponentModel.DataAnnotations;
using CategoryValidationMessages = StockMePhotos.GCommon.ValidationMessages.Category;
using CategoryDataValidation = StockMePhotos.Data.Common.DataValidation.Category;

namespace StockMePhotos.ViewModels.Category
{
    public class UpdateCategoryFormModel
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        [Required(ErrorMessage = CategoryValidationMessages.SlugRequired)]
        [MinLength(CategoryDataValidation.SlugMinLength, ErrorMessage = CategoryValidationMessages.SlugMinLength)]
        [MaxLength(CategoryDataValidation.SlugMaxLength, ErrorMessage = CategoryValidationMessages.SlugMaxLength)]
        public string Slug { get; set; } = null!;

        [Required(ErrorMessage = CategoryValidationMessages.DescriptionRequired)]
        [MinLength(CategoryDataValidation.DescriptionMinLength, ErrorMessage = CategoryValidationMessages.DescriptionMinLength)]
        [MaxLength(CategoryDataValidation.DescriptionMaxLength, ErrorMessage = CategoryValidationMessages.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public string? DateCreated { get; set; }
    }
}
