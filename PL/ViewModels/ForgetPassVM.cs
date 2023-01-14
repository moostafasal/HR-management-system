using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels
{
    public class ForgetPassVM
    {
        [Required(ErrorMessage = "Email is reqouerd")]
        [EmailAddress(ErrorMessage = "Invald Email")]
        public string Email { get; set; }
    }
}
