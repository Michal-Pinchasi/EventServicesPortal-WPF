using Model;
using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SellerDB:PeopleDB
    {
        public override BaseEntity NewEntity()
        {
            return new Seller() as BaseEntity;
        }
        public override BaseEntity CreateModel(BaseEntity be)
        {
            Seller c = be as Seller;
            c.Id = (int)reader["Id"];
            base.CreateModel(c);
            return c;
        }
        public Sellerlist SelectAll()
        {
            command.CommandText = " SELECT People.* FROM People inner join seller on People.id = seller.id";
            Sellerlist CustL = new Sellerlist(base.Select());
            return CustL;

        }
        public void Insert(Seller c)
        {
            base.Insert(c as Seller);
            string text = string.Format("insert into seller (id ) values" + " ({0})", c.Id);
            base.SaveChanges(text);
        }
        public void Update(Seller c)
        {
            base.Update(c as People);

        }
        public Seller SelectById(int id)
        {
            command.CommandText = "SELECT People.* FROM People inner join seller on People.id = seller.id where seller.id=" + id.ToString();
            Sellerlist lst = new Sellerlist(base.Select());
            if (lst.Count > 0)
                return lst[0];
            return null;
        }

        public Seller SelectByPhone(string phone)
        {
            command.CommandText = "SELECT People.* FROM People inner join seller on People.id = seller.id where People.Phone= '" + phone +"'";
            Sellerlist lst = new Sellerlist(base.Select());
            if (lst.Count > 0)
                return lst[0];
            return null;
        }
    }
}
