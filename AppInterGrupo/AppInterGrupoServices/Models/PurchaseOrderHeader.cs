using System;
using System.Collections.Generic;
using System.Text;

namespace AppInterGrupoServices.Models
{
    public class PurchaseOrderHeader
    {
        public int PurchaseOrderID { get; set; }
        public int RevisionNumber { get; set; }
        public int Status { get; set; }
        public int EmployeeID { get; set; }
        public Vendor Vendor { get; set; }
        public ShipMethod ShipMethod { get; set; }
        public List<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
