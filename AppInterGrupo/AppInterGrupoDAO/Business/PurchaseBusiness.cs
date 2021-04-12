using AppInterGrupoDAO.DAO;
using AppInterGrupoServices;
using AppInterGrupoServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppInterGrupoDAO.Business
{
    public class PurchaseBusiness : IPurchase
    {
        public List<PurchaseOrderHeader> GetPurchaseOrderHeader()
        {
            try
            {
                PurchaseDAO purchaseDAO = new PurchaseDAO();
                return purchaseDAO.GetPurchaseOrderHeader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PurchaseOrderHeader> GetPurchaseOrderHeaderByPurchaseOrderID(int purchaseOrderID)
        {
            try
            {
                PurchaseDAO purchaseDAO = new PurchaseDAO();
                return purchaseDAO.GetPurchaseOrderHeaderByPurchaseOrderID(purchaseOrderID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
