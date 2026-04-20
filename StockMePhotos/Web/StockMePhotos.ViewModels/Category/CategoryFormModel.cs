using CategoryValidationMessages = StockMePhotos.GCommon.ValidationMessages.Category;
using CategoryDataValidation = StockMePhotos.Data.Common.DataValidation.Category;
using System.ComponentModel.DataAnnotations;

namespace StockMePhotos.ViewModels.Category
{
    public class CategoryFormModel
    {
        [Required(ErrorMessage = CategoryValidationMessages.NameRequired)]
        [MinLength(CategoryDataValidation.NameMinLength,ErrorMessage = CategoryValidationMessages.NameMinLength)]
        [MaxLength(CategoryDataValidation.NameMaxLength, ErrorMessage = CategoryValidationMessages.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = CategoryValidationMessages.DescriptionRequired)]
        [MinLength(CategoryDataValidation.DescriptionMinLength, ErrorMessage = CategoryValidationMessages.DescriptionMinLength)]
        [MaxLength(CategoryDataValidation.DescriptionMaxLength, ErrorMessage = CategoryValidationMessages.DescriptionMaxLength)]
        public string Description { get; set; } = null!;
    }
}
