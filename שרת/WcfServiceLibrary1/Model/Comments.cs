using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Comments:BaseEntity
    {
		private Business  businessid;

		public Business Businessid
		{
			get { return businessid; }
			set { businessid = value; }
		}
		private Costumer  costumerid;

		public Costumer Costumerid
		{
			get { return costumerid; }
			set { costumerid = value; }
		}
		private string description;

		public string Description
        {
			get { return description; }
			set { description = value; }
		}
		private string image;

		public string Image
		{
			get { return image; }
			set { image = value; }
		}

	}
}
