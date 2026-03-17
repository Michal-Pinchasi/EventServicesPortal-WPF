using Model;
using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CommentsDB :BaseDB
    {
        public override BaseEntity NewEntity()
        {
            return new Comments() as BaseEntity;
        }

        public Commentslist SelectAll()
        {
            command.CommandText = "SELECT * FROM Comments";
            Commentslist citiesL = new Commentslist(base.Select());
            return citiesL;
        }

        public override BaseEntity CreateModel(BaseEntity be)
        {
            Comments b = be as Comments;
            b.Id = (int)reader["Id"];
            int businessid = Convert.ToInt32(reader["Businessid"]);
            b.Businessid = new BusinessDB().SelectById(businessid);
            int costumerid= Convert.ToInt32(reader["Costumerid"]);
            b.Costumerid = new CostumerDB().SelectById(costumerid);
            b.Description = reader["Description"].ToString();
            b.Image = reader["Image"].ToString();
            return b;
        }
        public void Insert(Comments p)
        {

            string text = string.Format("insert into comments (businessid,costumerid, description,image) values  ({0},{1},'{2}','{3}')", p.Businessid.Id , p.Costumerid.Id, p.Description, p.Image);

            base.SaveChanges(text);
        }
        public void Update(Comments p)
        {
            string sqlText = string.Format("update comments set  businessid={0} ,costumerid={1},description='{2}',image='{3}' WHERE Id={4}", p.Businessid.Id, p.Costumerid.Id, p.Description, p.Image, p.Id);
            base.SaveChanges(sqlText);
        }
        public Comments SelectById(int id)
        {
            command.CommandText = "select * from comments where comments.id=" + id.ToString();
            Commentslist lst = new Commentslist(base.Select());
            if (lst.Count > 0)
                return lst[0];
            return null;
        }
    }
}
