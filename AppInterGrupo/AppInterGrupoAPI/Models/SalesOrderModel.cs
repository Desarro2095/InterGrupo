using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppInterGrupoAPI.Models
{
    public class SalesOrderModel
    {
        public int SalesOrderID { get; set; }
        public int RevisionNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string AccountNumber { get; set; }
        public decimal TotalDue { get; set; }
        public string Comment { get; set; }
    }
}
