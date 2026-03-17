using Model;
using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class TakendatesDB:BaseDB
    {
        public override BaseEntity NewEntity()
        {
            return new Takendates() as BaseEntity;
        }

        public Takendateslist SelectAll()
        {
            command.CommandText = "SELECT * FROM Takendates";
            Takendateslist citiesL = new Takendateslist(base.Select());
            return citiesL;
        }

        public override BaseEntity CreateModel(BaseEntity be)
        {
            Takendates b = be as Takendates;
            b.Id = (int)reader["Id"];
            int sellerid=Convert.ToInt32(reader["Sellerid"]);
            b.Sellerid = new SellerDB().SelectById(sellerid);
            b.Takendate=Convert.ToDateTime (reader["Takendate"].ToString());
            return b;
        }
        public Takendates SelectById(int id)
        {
            command.CommandText = "select * from takendates where takendates.id=" + id.ToString();
            Takendateslist lst = new Takendateslist(base.Select());
            if (lst.Count > 0)
                return lst[0];
            return null;
        }
        public void Insert(Takendates p)
        {

            string text = string.Format("insert into takendates (sellerid, takendate) values  ({0},'{1}')", p.Sellerid.Id, p.Takendate.ToString("yyyy-MM-dd"));

            base.SaveChanges(text);
        }
        public void Update(Takendates p)
        {
            string sqlText = string.Format("update takendates set ,sellerid={0} ,takendate='{1}' WHERE Id={2}", p.Sellerid.Id, p.Takendate,p.Id);
            base.SaveChanges(sqlText);
        }
    }
}
