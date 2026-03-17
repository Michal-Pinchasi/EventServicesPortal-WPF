using Model;
using modle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ChatDB : BaseDB
    {
        public override BaseEntity NewEntity()
        {
            return new Chat() as BaseEntity;
        }

        public override BaseEntity CreateModel(BaseEntity be)
        {
            Chat t = be as Chat;
            t.Id = (int)reader["Id"];
            t.Remarks = reader["Remarks"].ToString();
            int e = (int)reader["PeopleWriter"];
            PeopleDB peopleDB = new PeopleDB();
            t.PeopleWriter  = peopleDB.SelectById(e);
            e = (int)reader["PeopleAccept"];
            t.PeopleAccept = peopleDB.SelectById(e);
           
            //e = (int)reader["Business"];
            BusinessDB businessDB = new BusinessDB();
           // t.Business= businessDB.SelectById(e);
            t.Read = Convert.ToBoolean(reader["Read"]);
            return t;
        }

        public Chatlist SelectAll()
        {
            command.CommandText = "SELECT * FROM Chat";
            Chatlist ChatList = new Chatlist(base.Select());
            return ChatList;
        }


        public void Insert(Chat Chat, Seller  writer,Costumer  accept)
        {
            /*HH:MI:SS*/
            Chat.PeopleWriter = writer;
            Chat.PeopleAccept = accept;
            string sqlStr = String.Format("INSERT INTO Chat (Remarks,ChatDate,PeopleWriter,PeopleAccept,[Read])  values('{0}','{1}',{2},{3},'{4}')", Chat.Remarks, Chat.ChatDate.ToString("yyyy-MM-dd"), Chat.PeopleWriter.Id,Chat.PeopleAccept.Id,Chat.Read);
            base.SaveChanges(sqlStr);
            Chat.Id = LastId;
        }

        public void Insert1(Chat Chat, Costumer  writer, Seller  accept)
        {
            Chat.PeopleWriter = writer;
            Chat.PeopleAccept = accept;
            /*HH:MI:SS*/
            string sqlStr = String.Format("INSERT INTO Chat (Remarks,ChatDate,PeopleWriter,PeopleAccept,[Read])  values('{0}','{1}',{2},{3},'{4}')", Chat.Remarks, Chat.ChatDate.ToString("yyyy-MM-dd"), Chat.PeopleWriter.Id, Chat.PeopleAccept.Id, Chat.Read);
            base.SaveChanges(sqlStr);
            Chat.Id = LastId;
        }
    }
}
