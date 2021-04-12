using AppInterGrupoDAO.Connection;
using AppInterGrupoServices.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AppInterGrupoDAO.DAO
{
    public class SalesDAO
    {
        public List<SalesOrderHeader> GetSalesOrderHeader()
        {
            string sql = "SELECT TOP 10 * FROM Sales.SalesOrderHeader AS SalesOrderHeader " +
                        "INNER JOIN Sales.Customer AS Customer ON Customer.CustomerID = SalesOrderHeader.CustomerID " +
                        "INNER JOIN Sales.SalesPerson AS SalesPerson ON SalesPerson.BusinessEntityID = SalesOrderHeader.SalesPersonID " +
                        "INNER JOIN Sales.SalesTerritory AS SalesTerritory ON SalesTerritory.TerritoryID = SalesOrderHeader.TerritoryID " +
                        "INNER JOIN Person.Address AS Address ON Address.AddressID = SalesOrderHeader.BillToAddressID " +
                        "INNER JOIN Purchasing.ShipMethod AS ShipMethod ON ShipMethod.ShipMethodID = SalesOrderHeader.ShipMethodID;";

            using (var connection = new SqlConnection(ConnectionString.ConnectionName))
            {
                var salesOrderHeaderDictionary = new Dictionary<int, SalesOrderHeader>();

                var list = connection.Query<SalesOrderHeader, Customer, SalesPerson, SalesTerritory, Address, ShipMethod, SalesOrderHeader>( 
                sql,
                (order, customer, salePerson, salesTerritory, billAddress, shipMethod) =>
                {
                    SalesOrderHeader orderEntry;
                    orderEntry = order;
                    orderEntry.Customer = customer;
                    orderEntry.SalesPerson = salePerson;
                    orderEntry.SalesTerritory = salesTerritory;
                    orderEntry.BillToAddress = billAddress;
                    orderEntry.ShipToAddress = billAddress;
                    orderEntry.ShipMethod = shipMethod;
                    orderEntry.CreditCard = GetCreditCard(orderEntry.SalesOrderID);
                    orderEntry.CurrencyRate = GetCurrencyRate(orderEntry.SalesOrderID);

                    return orderEntry;
                }, splitOn: "CustomerID,BusinessEntityID,TerritoryID,AddressID,ShipMethodID")
                .Distinct()
                .ToList(); 

                return list;
            }
        }

        public List<SalesOrderHeader> GetSalesOrderHeaderBySalesOrderID(int salesOrderID)
        {
            string sql = "SELECT TOP 50 * FROM Sales.SalesOrderHeader AS SalesOrderHeader " +
                        "INNER JOIN Sales.Customer AS Customer ON Customer.CustomerID = SalesOrderHeader.CustomerID " +
                        "INNER JOIN Sales.SalesPerson AS SalesPerson ON SalesPerson.BusinessEntityID = SalesOrderHeader.SalesPersonID " +
                        "INNER JOIN Sales.SalesTerritory AS SalesTerritory ON SalesTerritory.TerritoryID = SalesOrderHeader.TerritoryID " +
                        "INNER JOIN Person.Address AS Address ON Address.AddressID = SalesOrderHeader.BillToAddressID " +
                        "INNER JOIN Purchasing.ShipMethod AS ShipMethod ON ShipMethod.ShipMethodID = SalesOrderHeader.ShipMethodID WHERE SalesOrderHeader.SalesOrderID = @SalesOrderID;";

            using (var connection = new SqlConnection(ConnectionString.ConnectionName))
            {
                var salesOrderHeaderDictionary = new Dictionary<int, SalesOrderHeader>();

                var list = connection.Query<SalesOrderHeader, Customer, SalesPerson, SalesTerritory, Address, ShipMethod, SalesOrderHeader>(
                sql,
                (order, customer, salePerson, salesTerritory, billAddress, shipMethod) =>
                {
                    SalesOrderHeader orderEntry;
                    orderEntry = order;
                    orderEntry.Customer = customer;
                    orderEntry.SalesPerson = salePerson;
                    orderEntry.SalesTerritory = salesTerritory;
                    orderEntry.BillToAddress = billAddress;
                    orderEntry.ShipToAddress = billAddress;
                    orderEntry.ShipMethod = shipMethod;
                    orderEntry.CreditCard = GetCreditCard(orderEntry.SalesOrderID);
                    orderEntry.CurrencyRate = GetCurrencyRate(orderEntry.SalesOrderID);

                    return orderEntry;
                }, new { SalesOrderID = salesOrderID }, splitOn: "CustomerID,BusinessEntityID,TerritoryID,AddressID,ShipMethodID")
                .Distinct()
                .ToList();

                return list;
            }
        }

        public CreditCard GetCreditCard(int salesOrderID)
        {
            string sql = "SELECT TOP 1 CreditCard.* FROM Sales.SalesOrderHeader AS SalesOrderHeader INNER JOIN Sales.CreditCard AS CreditCard ON CreditCard.CreditCardID = SalesOrderHeader.CreditCardID WHERE SalesOrderID = @SalesOrderID;";
            using (var connection = new SqlConnection(ConnectionString.ConnectionName))
            {
                CreditCard creditCard = connection.Query<CreditCard>(sql, new { SalesOrderID = salesOrderID }).FirstOrDefault();
                return creditCard;
            }
        }

        public CurrencyRate GetCurrencyRate(int salesOrderID)
        {
            string sql = "SELECT TOP 1 CurrencyRate.* FROM Sales.SalesOrderHeader AS SalesOrderHeader INNER JOIN Sales.CurrencyRate AS CurrencyRate ON CurrencyRate.CurrencyRateID = SalesOrderHeader.CurrencyRateID WHERE SalesOrderID = @SalesOrderID;";
            using (var connection = new SqlConnection(ConnectionString.ConnectionName))
            {
                CurrencyRate currencyRate = connection.Query<CurrencyRate>(sql, new { SalesOrderID = salesOrderID }).FirstOrDefault();
                return currencyRate;
            }
        }

        public SalesOrderHeader UpdateSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString.ConnectionName))
            {
                string sqlQuery = "UPDATE Sales.SalesOrderHeader SET " +
                    "Comment='" + salesOrderHeader.Comment +
                    "',ModifiedDate='" + salesOrderHeader.ModifiedDate.ToString("MM/dd/yyyy H:mm") +
                    "' WHERE SalesOrderID=" + salesOrderHeader.SalesOrderID;

                int rowsAffected = db.Execute(sqlQuery);
            }
            return salesOrderHeader;
        }
    }
}
