using AppInterGrupoDAO.Business;
using AppInterGrupoServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppInterGrupoDAO
{
    public class InterGrupoOperation
    {
        public static ISales SalesOperations()
        {
            return new SalesBusiness();
        }

        public static IPurchase PurchaseOperations()
        {
            return new PurchaseBusiness();
        }
    }
}
