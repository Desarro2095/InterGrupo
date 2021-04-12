using System;
using System.Collections.Generic;
using System.Text;

namespace AppInterGrupoServices.Models
{
    public class SalesOrderHeader
    {
        public int SalesOrderID { get; set; }
        public int RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ShipDate { get; set; }
        public int Status { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public string SalesOrderNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string AccountNumber { get; set; }
        public Customer Customer { get; set; } 
        public SalesPerson SalesPerson { get; set; }
        public SalesTerritory SalesTerritory { get; set; }
        public Address BillToAddress { get; set; }
        public Address ShipToAddress { get; set; }
        public ShipMethod ShipMethod { get; set; }
        public CreditCard CreditCard { get; set; }
        public string CreditCardApprovalCode { get; set; }
        public CurrencyRate CurrencyRate { get; set; } 
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public string Comment { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
