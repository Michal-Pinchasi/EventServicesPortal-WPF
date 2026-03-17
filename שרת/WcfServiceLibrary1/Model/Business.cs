using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Business:BaseEntity
    {
		private Categories categoriesid;

		public Categories Categoriesid
        {
			get { return categoriesid; }
			set { categoriesid = value; }
		}
		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		private Seller sellerid;

		public Seller Sellerid
		{
			get { return sellerid; }
			set { sellerid = value; }
		}
		private string description;

		public string Description
        {
			get { return description; }
			set { description = value; }
		}
		private string image1;

		public string Image1
        {
			get { return image1; }
			set { image1 = value; }
		}
        private string image2;

        public string Image2
        {
            get { return image2; }
            set { image2 = value; }
        }
        private string image3;

        public string Image3
        {
            get { return image3; }
            set { image3 = value; }
        }

    }
}
