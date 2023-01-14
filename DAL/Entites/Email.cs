using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
	public class Email
	{
        public int Id { get; set; } //=> if we need to mak it table :)
        public string Title { get; set; }
        public string Body { get; set; }
        public string To { get; set; }

    }
}
