using System.ComponentModel.DataAnnotations;

namespace PL.ViewModels
{
	public class RegersterViewModel
	{
		[Required(ErrorMessage ="Email is reqouerd")]
		[EmailAddress(ErrorMessage ="Invald Email")]
		public string Email { get; set; }

		[Required(ErrorMessage ="password is req")]
		[MinLength(5,ErrorMessage ="minmum is 5")]
		[DataType(DataType.Password)]
		public string password { get; set; }

        [Required]
		[Compare(nameof(password),ErrorMessage ="NOT MATCH")]
        public string ConfirmPasword { get; set; }
        [Required]

        public bool IsAgree { get; set; }
	}
}
