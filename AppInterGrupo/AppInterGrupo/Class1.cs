using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace AppInterGrupo
{
    public class Class1
    {
        public List<PersonPhone> GetTest()
        {
			string sqlOrderDetails = "SELECT TOP 5 * FROM Person.PersonPhone;";
			//string sqlOrderDetail = "SELECT * FROM OrderDetails WHERE OrderDetailID = @OrderDetailID;";
			//string sqlCustomerInsert = "INSERT INTO Customers (CustomerName) Values (@CustomerName);";

			//using (var connection = new SqlConnection(FiddleHelper.GetConnectionStringSqlServerW3Schools()))
			using (var connection = new SqlConnection("Data Source=LAPTOP-BT5NAMU2; Initial Catalog=AdventureWorks2019;User ID=carlos;Password=123"))
			{
				var phones = connection.Query<PersonPhone>(sqlOrderDetails).ToList();
				//var orderDetail = connection.QueryFirstOrDefault<OrderDetail>(sqlOrderDetail, new { OrderDetailID = 1 });
				//var affectedRows = connection.Execute(sqlCustomerInsert, new { CustomerName = "Mark" });

				return phones;
				//Console.WriteLine(orderDetails.Count);
				//Console.WriteLine(affectedRows);

				//FiddleHelper.WriteTable(orderDetails);
				//FiddleHelper.WriteTable(new List<OrderDetail>() { orderDetail });
			}
		}
    }
}
