using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Takendates : BaseEntity
    {
		private Seller sellerid;

		public Seller Sellerid
		{
			get { return sellerid; }
			set { sellerid = value; }
		}
		private DateTime takendate;

		public DateTime Takendate
        {
			get { return takendate; }
			set { takendate = value; }
		}

	}
}
