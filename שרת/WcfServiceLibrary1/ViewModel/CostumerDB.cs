using Model;
using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CostumerDB:PeopleDB
    {
        public override BaseEntity NewEntity()
        {
            return new Costumer() as BaseEntity;
        }

        public Costumerlist SelectAll()
        {
            command.CommandText = "SELECT People.* FROM People inner join costumer on costumer.id = people.id";
            Costumerlist citiesL = new Costumerlist(base.Select());
            return citiesL;
        }

        public override BaseEntity CreateModel(BaseEntity be)
        {
            Costumer b = be as Costumer;
            b.Id = (int)reader["Id"];
            base.CreateModel(b);
            return b;
        }
        public void Insert(Costumer c)
        {
            base.Insert(c as People);
            string text = string.Format("insert into Costumer (id ) values" + " ({0})", c.Id);
            base.SaveChanges(text);
        }
        public void Update(Costumer c)
        {
            base.Update(c as People);
         
        }
        public Costumer SelectById(int id)
        {
            command.CommandText = "SELECT People.* FROM People inner join costumer on costumer.id = people.id where costumer.id=" + id.ToString();
            Costumerlist lst = new Costumerlist(base.Select());
            if (lst.Count > 0)
                return lst[0];
            return null;
        }
        public Costumer SelectByPhone(string phone)
        {
            command.CommandText = "SELECT People.* FROM People inner join costumer on People.id = costumer.id where People.Phone= '" + phone + "'";
            Costumerlist lst = new Costumerlist(base.Select());
            if (lst.Count > 0)
                return lst[0];
            return null;
        }
    }
}
