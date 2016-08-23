using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SFCart
{
    [ServiceContract]
    public interface ICart
    {
        [OperationContract(Name = "AddItem")]
        [WebInvoke(Method = "POST",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               UriTemplate = "/AddItem")]
        bool AddItem(int id);

        [OperationContract(Name = "RemoveItem")]
        [WebInvoke(Method = "POST",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               UriTemplate = "/RemoveItem")]
        bool RemoveItem(int id);

        [OperationContract(Name = "ClearItems")]
        [WebInvoke(Method = "POST",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               UriTemplate = "/RemoveItem")]
        bool ClearItems();

        [OperationContract(Name = "GetCartItems")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Cart")]
        List<Item> GetCartItems();

        [OperationContract(Name = "GetShopItems")]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Shop")]
        List<Item> GetStoreItems();

        [OperationContract(Name = "GetStatus")]
        [WebInvoke(Method = "GET",
               RequestFormat = WebMessageFormat.Json,
               ResponseFormat = WebMessageFormat.Json,
               UriTemplate = "/Status")]
        Status GetStatus();
    }

    [DataContract]
    public class Item
    {
        public Item(int id, double price, string name, int amount)
        {
            ID = id;
            Price = price;
            Name = name;
            Amount = amount;
        }

        [DataMember]
        public int ID
        {
            get; set;
        }

        [DataMember]
        public double Price
        {
            get; set;
        }

        [DataMember]
        public string Name
        {
            get; set;
        }

        [DataMember]
        public int Amount
        {
            get; set;
        }
    }

    [DataContract]
    public class Status
    {
        [DataMember]
        public string Message
        {
            get; set;
        }

        [DataMember]
        public string Detail
        {
            get; set;
        }

        [DataMember]
        public STATE State
        {
            get; set;
        }

        public enum STATE
        {
            OK,
            Error
        };
    }    
}
