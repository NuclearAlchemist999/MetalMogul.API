using System.ComponentModel.DataAnnotations;

namespace MetalMogul.Dto.Request
{
    public class BookTicketsRequestDto
    {
        [Required(ErrorMessage = "First name is required.")]
        [MinLength(2, ErrorMessage = "At least two characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        [MinLength(2, ErrorMessage = "At least two characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
