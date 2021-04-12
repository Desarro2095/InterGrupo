using AppInterGrupoServices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppInterGrupoServices
{
    public interface IPurchase
    {
        List<PurchaseOrderHeader> GetPurchaseOrderHeader();
        List<PurchaseOrderHeader> GetPurchaseOrderHeaderByPurchaseOrderID(int purchaseOrderID);
    }
}
