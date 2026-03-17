using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using ViewModel;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
       

        [OperationContract]
        Businesslist SelectAllbusiness();
        
        [OperationContract]
        Business SelectByIdbusiness(int id);

        [OperationContract]
        void Insertbusiness(Business p);

        [OperationContract]
        void Updatebusiness(Business p);
        
        [OperationContract]
        Categorieslist SelectAllcategories();
        
        [OperationContract]
        Categories SelectByIdcategories(int id);
        [OperationContract]
        void Insertcategories(Categories p);
        [OperationContract]
        void Updatecategories(Categories p);
        [OperationContract]
        Citylist SelectAllcity();
        [OperationContract]
        City SelectByIdcity(int id);
        [OperationContract]
        void Insertcity(City p);
        [OperationContract]
        void Updatecity(City city);
        [OperationContract]
        Commentslist SelectAllcomments();
        [OperationContract]
        void Insertcomments(Comments p);
        [OperationContract]
        void Updatecomments(Comments p);
        [OperationContract]
        Comments SelectByIdcomments(int id);
        [OperationContract]
        Costumerlist SelectAllcostumer();
        [OperationContract]
        void Insertcostumer(Costumer c);
        [OperationContract]
        void Updatecostumer(Costumer c);
        [OperationContract]
        Costumer SelectByIdcostumer(int id);
        [OperationContract]
        void Insertpeople(People p);
        [OperationContract]
        void Updatepeople(People p);
        [OperationContract]
        Sellerlist SelectAllseller();
        [OperationContract]
        void Insertseller(Seller c);
        [OperationContract]
        void Updateseller(Seller c);
        [OperationContract]
        Seller SelectByIdsekller(int id);
        [OperationContract]
        Takendateslist SelectAlltakendates();
        [OperationContract]
        Takendates SelectByIdtakendates(int id);
        [OperationContract]
        void Inserttakendates(Takendates p);
        [OperationContract]
        void Updatetakendates(Takendates p);
        [OperationContract]
        Seller selectbyphoneseller(string phone); 
        [OperationContract]
        People SelectByIdpeople(int id);
        [OperationContract]
        Chatlist SelectAllChat();
        [OperationContract]
        void InsertCat(Chat chat, Seller writer, Costumer accept);
        [OperationContract]
        void InsertCat1(Chat chat, Costumer  writer, Seller accept);
        [OperationContract]
        Costumer selectbyphonecostumer(string phone);  /*לא עשיתי גם בסרבר */

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WcfServiceLibrary1.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
