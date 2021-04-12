using AppInterGrupoDAO.Connection;
using AppInterGrupoServices.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using Dapper;

namespace AppInterGrupoDAO.DAO
{
    public class PurchaseDAO
    {
        public List<PurchaseOrderHeader> GetPurchaseOrderHeader()
        {
            string sql = "SELECT TOP 50 * FROM Purchasing.PurchaseOrderHeader PurchaseOrderHeader " +
                        "INNER JOIN Purchasing.Vendor Vendor ON Vendor.BusinessEntityID = PurchaseOrderHeader.VendorID " + 
                        "INNER JOIN Purchasing.ShipMethod ShipMethod ON ShipMethod.ShipMethodID = PurchaseOrderHeader.ShipMethodID " +
                        "INNER JOIN Purchasing.PurchaseOrderDetail ON PurchaseOrderDetail.PurchaseOrderID = PurchaseOrderHeader.PurchaseOrderID; ";

            using (var connection = new SqlConnection(ConnectionString.ConnectionName))
            {
                var salesOrderHeaderDictionary = new Dictionary<int, SalesOrderHeader>();

                var list = connection.Query<PurchaseOrderHeader, Vendor, ShipMethod, PurchaseOrderDetail, PurchaseOrderHeader >(
                sql,
                (purchase, vendor, shipMethod, purchaseOrderDetail) =>
                {
                    PurchaseOrderHeader purchaseOrderEntry;
                    purchaseOrderEntry = purchase;
                    purchaseOrderEntry.Vendor = vendor;
                    purchaseOrderEntry.ShipMethod = shipMethod;
                    purchaseOrderEntry.PurchaseOrderDetails = new List<PurchaseOrderDetail>();
                    purchaseOrderEntry.PurchaseOrderDetails.Add(purchaseOrderDetail);

                    return purchaseOrderEntry;
                }, splitOn: "BusinessEntityID,ShipMethodID,PurchaseOrderID")
                .Distinct()
                .ToList();

                return list;
            }
        }

        public List<PurchaseOrderHeader> GetPurchaseOrderHeaderByPurchaseOrderID(int purchaseOrderID)
        {
            string sql = "SELECT TOP 50 * FROM Purchasing.PurchaseOrderHeader PurchaseOrderHeader " +
                        "INNER JOIN Purchasing.Vendor Vendor ON Vendor.BusinessEntityID = PurchaseOrderHeader.VendorID " +
                        "INNER JOIN Purchasing.ShipMethod ShipMethod ON ShipMethod.ShipMethodID = PurchaseOrderHeader.ShipMethodID " +
                        "INNER JOIN Purchasing.PurchaseOrderDetail ON PurchaseOrderDetail.PurchaseOrderID = PurchaseOrderHeader.PurchaseOrderID WHERE PurchaseOrderHeader.PurchaseOrderID = @PurchaseOrderID; ";

            using (var connection = new SqlConnection(ConnectionString.ConnectionName))
            {
                var salesOrderHeaderDictionary = new Dictionary<int, SalesOrderHeader>();

                var list = connection.Query<PurchaseOrderHeader, Vendor, ShipMethod, PurchaseOrderDetail, PurchaseOrderHeader>(
                sql,
                (purchase, vendor, shipMethod, purchaseOrderDetail) =>
                {
                    PurchaseOrderHeader purchaseOrderEntry;
                    purchaseOrderEntry = purchase;
                    purchaseOrderEntry.Vendor = vendor;
                    purchaseOrderEntry.ShipMethod = shipMethod;
                    purchaseOrderEntry.PurchaseOrderDetails = new List<PurchaseOrderDetail>();
                    purchaseOrderEntry.PurchaseOrderDetails.Add(purchaseOrderDetail);

                    return purchaseOrderEntry;
                }, new { PurchaseOrderID = purchaseOrderID }, splitOn: "BusinessEntityID,ShipMethodID,PurchaseOrderID")
                .Distinct()
                .ToList();

                return list;
            }
        }
    }
}
