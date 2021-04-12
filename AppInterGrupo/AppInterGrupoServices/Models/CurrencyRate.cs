using System;
using System.Collections.Generic;
using System.Text;

namespace AppInterGrupoServices.Models
{
    public class CurrencyRate
    {
        public int CurrencyRateID { get; set; }
        public DateTime CurrencyRateDate { get; set; }
        public string FromCurrencyCode { get; set; }
        public string ToCurrencyCode { get; set; }
        public decimal AverageRate { get; set; }
        public decimal EndOfDayRate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
