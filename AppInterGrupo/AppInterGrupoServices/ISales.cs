using AppInterGrupoServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppInterGrupoServices
{
    public interface ISales
    {
        List<SalesOrderHeader> GetSalesOrderHeader();
        List<SalesOrderHeader> GetSalesOrderHeaderBySalesOrderID(int salesOrderID);
        SalesOrderHeader UpdateSalesOrderHeader(int salesOrderID, string comment);
    }
}
