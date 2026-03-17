using Model;
using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PeopleDB:BaseDB
    {
        public override BaseEntity NewEntity()
        {
            return new People() as BaseEntity;
        }

        //public Peoplelist SelectAll()
        //{
        //    command.CommandText = "SELECT * FROM People";
        //    Peoplelist citiesL = new Peoplelist(base.Select());
        //    return citiesL;
        //}

        public override BaseEntity CreateModel(BaseEntity be)
        {
            People b = be as People;
            b.Id = (int)reader["Id"];
            b.Firstname = reader["Firstname"].ToString();
            b.Lastname = reader["Lastname"].ToString();
            b.Phone = reader["Phone"].ToString();
            b.Code = reader["Code"].ToString();
            int city = Convert.ToInt32(reader["Cityid"]);
            b.C1 = new CityDB().SelectById(city);

            return b;
        }
        public void Insert(People p)
        {

            string text = string.Format("insert into People (Id,Firstname,Lastname,Phone, Code,Cityid) values   " + " ({0},'{1}','{2}','{3}','{4}',{5})", p.Id, p.Firstname, p.Lastname, p.Phone, p.Code, p.C1.Id);

            base.SaveChanges(text);
        }
        public void Update(People p)
        {
            string sqlText = string.Format("update People set Firstname='{0}' ,Lastname='{1}' ,Phone='{2}',Code='{3}',cityid={4} WHERE Id={5}", p.Firstname, p.Lastname, p.Phone, p.Code, p.C1.Id, p.Id);
            base.SaveChanges(sqlText);
           
        }
        public People SelectById(int id)
        {
            command.CommandText = "select * from people where people.id=" + id.ToString();
            Peoplelist lst = new Peoplelist(base.Select());
            if (lst.Count > 0)
                return lst[0];
            return null;
        }
    }
}
