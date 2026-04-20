using System.ComponentModel.DataAnnotations;
using TagValidationMessages = StockMePhotos.GCommon.ValidationMessages.Tag;
using TagDataValidation = StockMePhotos.Data.Common.DataValidation.Tag;

namespace StockMePhotos.ViewModels.Tag
{
    public class TagFormModel
    {
        [Required(ErrorMessage = TagValidationMessages.NameRequired)]
        [MinLength(TagDataValidation.NameMinLength, ErrorMessage = TagValidationMessages.NameMinLength)]
        [MaxLength(TagDataValidation.NameMaxLength, ErrorMessage = TagValidationMessages.NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
