using System.ComponentModel.DataAnnotations;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name of event is required.")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Even name should be between 3-50 characters.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Decription of event is required.")]
        [StringLength(500,ErrorMessage ="Discription over 500 chara.")]
        public string? Description { get; set; }
        [EmailAddress]
        public string? ContactEmail { get; set; }
    }
}
