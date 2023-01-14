using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels
{
	public class ResetPassVM
	{
        [Required]
        [MinLength(6, ErrorMessage = "Minimum Length is 6 chars")]

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Minimum Length is 6 chars")]

        [DataType(DataType.Password)]
        public string ConfermPassword { get; set; }
	}
}
