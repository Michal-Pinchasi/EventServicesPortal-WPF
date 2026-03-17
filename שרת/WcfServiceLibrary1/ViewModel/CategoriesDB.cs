using Model;
using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CategoriesDB:BaseDB
    {
        public override BaseEntity NewEntity()
        {
            return new Categories() as BaseEntity;
        }

        public Categorieslist SelectAll()
        {
            command.CommandText = "SELECT * FROM Categories";
            Categorieslist citiesL = new Categorieslist(base.Select());
            return citiesL;
        }

        public override BaseEntity CreateModel(BaseEntity be)
        {
            Categories b = be as Categories;
            b.Id = (int)reader["Id"];
            b.Name = reader["Name"].ToString();
          
            return b;





        }
    
      
        public Categories SelectById(int id)
        {
            command.CommandText = "select * from categories where categories.id=" + id.ToString();
            Categorieslist lst = new Categorieslist(base.Select());
            if (lst.Count > 0)
                return lst[0];
            return null;
        }
        public void Insert(Categories p)
        {

            string text = string.Format("insert into categories (name) values  ('{0}')", p.Name);

            base.SaveChanges(text);
        }
        public void Update(Categories p)
        {
            string sqlText = string.Format("update categories set  name='{0}' where categories.Id = {1} ", p.Name,p.Id );
            base.SaveChanges(sqlText);
        }
    }
}
