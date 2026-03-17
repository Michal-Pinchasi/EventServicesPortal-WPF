using Model;
using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CityDB : BaseDB
    {
        public Citylist SelectAll()
        {
            command.CommandText = "select * from City";
            Citylist clist = new Citylist(base.Select());
            return clist;
        }
        public override BaseEntity CreateModel(BaseEntity be)
        {
            City c = be as City;
            c.Id = (int)reader["Id"];
            c.Name = reader["Name"].ToString();
            return c;

        }
        public override BaseEntity NewEntity()
        {
            return new City() as BaseEntity;
        }
        public City SelectById(int id)
        {
            command.CommandText = "select * from city where city.id=" + id.ToString();
            Citylist cities = new Citylist(base.Select());
            if (cities.Count > 0)
                return cities[0];
            return null;
        }
       
        public void Insert(City p)
        {

            string text = string.Format("insert into city (name) values  ('{0}')", p.Name);

            base.SaveChanges(text);
        }
        public void Update(City city)
        {
            string sqlText = "UPDATE City set Name='" + city.Name + "' WHERE Id = " + city.Id;
            base.SaveChanges(sqlText);
        }
    }
}
