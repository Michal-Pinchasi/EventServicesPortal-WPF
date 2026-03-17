using Model;
using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ViewModel.BusinessDB;


namespace ViewModel
{
    public class BusinessDB : BaseDB
    {

        public override BaseEntity NewEntity()
        {
            return new Business() as BaseEntity;
        }

        public Businesslist SelectAll()
        {
            command.CommandText = "SELECT * FROM Business";
            Businesslist citiesL = new Businesslist(base.Select());
            return citiesL;
        }

        public override BaseEntity CreateModel(BaseEntity be)
        {
            Business b = be as Business;
            b.Id = (int)reader["Id"];
            int categories = Convert.ToInt32(reader["Categoriesid"]);
            b.Categoriesid = new CategoriesDB().SelectById(categories); 
            int seller = Convert.ToInt32(reader["sellerid"]);
            b.Sellerid = new SellerDB().SelectById(seller);
            b.Name = reader["Name"].ToString();
            b.Description = reader["Description"].ToString();
            b.Image1 = reader["Image1"].ToString();
            b.Image2 = reader["Image2"].ToString();
            b.Image3 = reader["Image3"].ToString();

            return b;
        }
        public Business SelectById(int id)
        {
            command.CommandText = "select * from business where business.id=" + id.ToString();
            Businesslist lst = new Businesslist(base.Select());
            if (lst.Count > 0)
                return lst[0];
            return null;
        }
        public void Insert(Business p)
        {

            string text = string.Format("insert into business (categoriesid,name, sellerid ,description,image1,image2,image3) values  ({0},'{1}',{2},'{3}','{4}','{5}','{6}')", p.Categoriesid.Id, p.Name, p.Sellerid.Id, p.Description,p.Image1,p.Image2,p.Image3);

            base.SaveChanges(text);
        }
        public void Update(Business p)
        {
            string sqlText = string.Format("update business set  categoriesid={0} ,name='{1}',sellerid={2},description='{3}',image1='{4}',image2='{5}',image3='{6}' WHERE Id={7}", p.Categoriesid.Id, p.Name, p.Sellerid.Id, p.Description, p.Image1,p.Image2,p.Image3,p.Id);
            base.SaveChanges(sqlText);
        }
    } 
}
