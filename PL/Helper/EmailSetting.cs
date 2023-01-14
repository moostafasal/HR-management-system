using DAL.Entites;
using System.Net;
using System.Net.Mail;

namespace PL.Helper
{
	public static class EmailSetting
	{
	public static void Send(Email email)
		{

			var smtp = new SmtpClient("smtp.office365.com", 587);
			smtp.EnableSsl = true;
			smtp.Credentials = new NetworkCredential("mostafasalemx420@outlook.com", "3038344mosta***");
			smtp.Send("mostafasalemx420@outlook.com", email.To, email.Title, email.Body);
		}
	}
}
