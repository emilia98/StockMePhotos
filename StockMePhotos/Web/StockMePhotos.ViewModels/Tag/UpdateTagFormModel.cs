using System.ComponentModel.DataAnnotations;
using TagDataValidation = StockMePhotos.Data.Common.DataValidation.Tag;
using TagValidationMessages = StockMePhotos.GCommon.ValidationMessages.Tag;

namespace StockMePhotos.ViewModels.Tag
{
    public class UpdateTagFormModel
    {
        public int? Id { get; set; }

        public string? Name { get; set; }

        [Required(ErrorMessage = TagValidationMessages.SlugRequired)]
        [MinLength(TagDataValidation.SlugMinLength, ErrorMessage = TagValidationMessages.SlugMinLength)]
        [MaxLength(TagDataValidation.SlugMaxLength, ErrorMessage = TagValidationMessages.SlugMaxLength)]
        public string Slug { get; set; } = null!;

        public string? DateCreated { get; set; }
    }
}
