using static StockMePhotos.GCommon.ValidationMessages.Photo;
using static StockMePhotos.Data.Common.DataValidation.Photo;
using System.ComponentModel.DataAnnotations;

using PhotoValidationMessages = StockMePhotos.GCommon.ValidationMessages.Photo;
using PhotoDataValidation = StockMePhotos.Data.Common.DataValidation.Photo;
using Microsoft.AspNetCore.Http;
using StockMePhotos.ViewModels.Category;

namespace StockMePhotos.ViewModels.Photo
{
    public class AddPhotoInputModel
    {
        [Required(ErrorMessage = PhotoValidationMessages.TitleRequired)]
        [MinLength(PhotoDataValidation.TitleMinLength, ErrorMessage = PhotoValidationMessages.TitleMinLength)]
        [MaxLength(PhotoDataValidation.TitleMaxLength, ErrorMessage = PhotoValidationMessages.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = PhotoValidationMessages.DescriptionRequired)]
        [MinLength(PhotoDataValidation.DescriptionMinLength, ErrorMessage = PhotoValidationMessages.DescriptionMinLength)]
        [MaxLength(PhotoDataValidation.DescriptionMaxLength, ErrorMessage = PhotoValidationMessages.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        // Should slug be generated automatically

        [Required(ErrorMessage = PhotoValidationMessages.ImageRequired)]
        public IFormFile Image { get; set; } = null!;
        // public IFormFile? Image { get; set; }

        [Required(ErrorMessage = PhotoValidationMessages.CategoryRequired)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
            = new List<CategoryViewModel>();

        [RegularExpression(@"^[a-zA-Z0-9&., ]*$", ErrorMessage = PhotoValidationMessages.TagsRules)]
        public string Tags { get; set; } = string.Empty;
    }
}
