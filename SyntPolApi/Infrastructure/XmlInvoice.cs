using SyntPolApi.Core.DTOs;
using SyntPolApi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using YAXLib;

namespace SyntPolApi.Infrastructure
{
    public class OrderItems : List<OrderItem> { }
    //[Serializable]
    //[XmlType("Invoice")]
    //[XmlRoot("Invoice")]
    public class XmlInvoice
    {
        public int InvoiceId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string SupplierName { get; set; }
        public string SupplierStreet { get; set; }
        public string SupplierCity { get; set; }
        public string SupplierZipCode { get; set; }
        public string SupplierNIP { get; set; }
        public string CustomerName { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerZipCode { get; set; }
        public string CustomerNIP { get; set; }
        //[XmlArray("OrderItems")]
        [YAXCollection(YAXCollectionSerializationTypes.Recursive,
                  EachElementName = "OrderItem")]
        public List<GetOrderItemForXml> OrderItems { get; set; }

        public XmlInvoice(int InvoiceId, DateTime IssueDate, DateTime DeliveryDate, 
            string SupplierName, string SupplierStreet, string SupplierCity, string SupplierZipCode, string SupplierNIP,
            string CustomerName, string CustomerStreet, string CustomerCity, string CustomerZipCode, string CustomerNIP, List<GetOrderItemForXml> OrderItems)
        {
            this.InvoiceId = InvoiceId;
            this.IssueDate = IssueDate;
            this.DeliveryDate = DeliveryDate;
            this.SupplierName = SupplierName;
            this.SupplierStreet = SupplierStreet;
            this.SupplierCity = SupplierCity;
            this.SupplierZipCode = SupplierZipCode;
            this.SupplierNIP = SupplierNIP;
            this.CustomerName = CustomerName;
            this.CustomerStreet = CustomerStreet;
            this.CustomerCity = CustomerCity;
            this.CustomerZipCode = CustomerZipCode;
            this.CustomerNIP = CustomerNIP;
            this.OrderItems = OrderItems;
        }
        
        public XmlInvoice()
        {

        }
    }
}
