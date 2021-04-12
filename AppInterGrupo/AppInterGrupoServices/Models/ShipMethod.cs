using System;
using System.Collections.Generic;
using System.Text;

namespace AppInterGrupoServices.Models
{
    public class ShipMethod
    {
        public int ShipMethodID { get; set; }
        public string Name { get; set; }
        public decimal ShipBase { get; set; }
        public decimal ShipRate { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
