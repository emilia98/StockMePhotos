using System.ComponentModel.DataAnnotations;

namespace StockMePhotos.ViewModels.Tag
{
    public class TagUpdateInputModel : TagFormInputModel
    {
        [Required]
        public int Id { get; set; }
    }
}
