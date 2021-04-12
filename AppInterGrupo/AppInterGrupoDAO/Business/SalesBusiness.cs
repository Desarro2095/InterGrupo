using AppInterGrupoDAO.DAO;
using AppInterGrupoServices;
using AppInterGrupoServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppInterGrupoDAO.Business
{
    public class SalesBusiness : ISales
    {
        public List<SalesOrderHeader> GetSalesOrderHeader()
        {
            try
            {
                SalesDAO salesDAO = new SalesDAO();
                return salesDAO.GetSalesOrderHeader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SalesOrderHeader> GetSalesOrderHeaderBySalesOrderID(int salesOrderID)
        {
            try
            {
                SalesDAO salesDAO = new SalesDAO();
                return salesDAO.GetSalesOrderHeaderBySalesOrderID(salesOrderID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SalesOrderHeader UpdateSalesOrderHeader(int salesOrderID, string comment)
        {
            try
            {
                SalesDAO salesDAO = new SalesDAO();
                SalesOrderHeader salesOrderHeader = salesDAO.GetSalesOrderHeaderBySalesOrderID(salesOrderID).FirstOrDefault();
                salesOrderHeader.Comment = comment;
                salesOrderHeader.ModifiedDate = DateTime.Now;
                return salesDAO.UpdateSalesOrderHeader(salesOrderHeader);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
