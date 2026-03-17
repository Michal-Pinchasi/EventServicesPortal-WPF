using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ViewModel;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}

        BusinessDB bDB = new BusinessDB();
        public Businesslist SelectAllbusiness()
        {
            return bDB.SelectAll();
        }
        public Business SelectByIdbusiness(int id)
        {
           return bDB.SelectById(id);
        }
       public void Insertbusiness(Business p)
        {
            bDB.Insert(p);
        }
       public void Updatebusiness(Business p)
        {
            bDB.Update(p);
        }
        CategoriesDB cDB= new CategoriesDB();
       public Categorieslist SelectAllcategories()
        {
            return cDB.SelectAll();
        }

        public Categories SelectByIdcategories(int id)
        {
            return cDB.SelectById(id);
        }

        public void Insertcategories(Categories p)
        {
            cDB.Insert(p);
        }

        public void Updatecategories(Categories p)
        {
            cDB.Update(p);
        }
        CityDB cityDB= new CityDB();
        public Citylist SelectAllcity()
        {
            return cityDB.SelectAll();
        }

        public City SelectByIdcity(int id)
        {
            return cityDB.SelectById(id);
        }

        public void Insertcity(City p)
        {
            cityDB.Insert(p);
        }

        public void Updatecity(City city)
        {
            cityDB.Update(city);
        }
        CommentsDB commentsDB= new CommentsDB();
        public Commentslist SelectAllcomments()
        {
            return commentsDB.SelectAll();  
        }

        public void Insertcomments(Comments p)
        {
           commentsDB.Insert(p);    
        }

        public void Updatecomments(Comments p)
        {
            commentsDB.Update(p);   
        }

        public Comments SelectByIdcomments(int id)
        {
            return commentsDB.SelectById(id);
        }
        CostumerDB costumerDB= new CostumerDB();    
        public Costumerlist SelectAllcostumer()
        {
            return costumerDB.SelectAll();  
        }

        public void Insertcostumer(Costumer c)
        {
            costumerDB.Insert(c);
        }

        public void Updatecostumer(Costumer c)
        {
            costumerDB.Update(c);
        }

        public Costumer SelectByIdcostumer(int id)
        {
            return costumerDB.SelectById(id);
        }
        PeopleDB PeopleDB = new PeopleDB();
        public void Insertpeople(People p)
        {
           PeopleDB.Insert(p);
        }



        public People SelectByIdpeople(int id)
        {
            return PeopleDB.SelectById(id);
        }

        public void Updatepeople(People p)
        {
            PeopleDB.Update(p);
        }
        SellerDB SellerDB= new SellerDB();
        public Sellerlist SelectAllseller()
        {
           return SellerDB.SelectAll();   
        }

        public void Insertseller(Seller c)
        {
           SellerDB.Insert(c);
        }

        public void Updateseller(Seller c)
        {
            SellerDB.Update(c);
        }

        public Seller SelectByIdsekller(int id)
        {
            return SellerDB.SelectById(id);
        }
       
        TakendatesDB TakendatesDB = new TakendatesDB();
        public Takendateslist SelectAlltakendates()
        {
            return TakendatesDB.SelectAll();
        }

        public Takendates SelectByIdtakendates(int id)
        {
           return TakendatesDB.SelectById(id);
        }

        public void Inserttakendates(Takendates p)
        {
            TakendatesDB.Insert(p);
        }

        public void Updatetakendates(Takendates p)
        {
            TakendatesDB.Update(p);
        }

        public Seller selectbyphoneseller(string phone)
        {
            return SellerDB.SelectByPhone(phone);
        }
        ChatDB chatDB = new ChatDB();

        public Chatlist SelectAllChat()
        {
            return chatDB.SelectAll();
        }
        public void InsertCat(Chat chat, Seller  writer, Costumer accept)
        {
            chatDB.Insert(chat,writer,accept);
        }

        public void InsertCat1(Chat chat, Costumer  writer, Seller accept)
        {
            chatDB.Insert1(chat, writer, accept);
        }

        public Costumer selectbyphonecostumer(string phone)
        {
            return costumerDB.SelectByPhone(phone);
        }
    }



}
