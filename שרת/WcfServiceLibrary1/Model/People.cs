using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class People:BaseEntity
    {
		private int id;

		
		private string firstname;

		public string Firstname
        {
			get { return firstname; }
			set { firstname = value; }
		}
		private string lastname;

		public string Lastname
        {
			get { return lastname; }
			set { lastname = value; }
		}
		private string phne;

		public string Phone
		{
			get { return phne; }
			set { phne = value; }
		}
		private string code;

		public string Code
		{
			get { return code; }
			set { code = value; }
		}
		private City c1;

		public City C1
		{
			get { return c1; }
			set { c1 = value; }
		}




	}
}
