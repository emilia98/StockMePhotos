using System.ComponentModel.DataAnnotations;
using static StockMePhotos.Data.Common.EntityConstants.Tag;
using static StockMePhotos.ViewModels.ValidationMessages.Tag;

namespace StockMePhotos.ViewModels.Tag
{
    public class TagFormInputModel
    {
        [Required(ErrorMessage = NameRequiredMessage)]
        [MinLength(NameMinLength, ErrorMessage = NameMinLengthMessage)]
        [MaxLength(NameMaxLength, ErrorMessage = NameMaxLengthMessage)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = SlugRequiredMessage)]
        [MinLength(SlugMinlength, ErrorMessage = SlugMinLengthMessage)]
        [MaxLength(SlugMaxLength, ErrorMessage = SlugMaxLengthMessage)]
        public string Slug { get; set; } = null!;

    }
}
