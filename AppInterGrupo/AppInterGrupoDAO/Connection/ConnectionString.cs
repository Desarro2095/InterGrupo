using System;
using System.Collections.Generic;
using System.Text;

namespace AppInterGrupoDAO.Connection
{
    public static class ConnectionString
    {
        private static string conName = "Data Source=LAPTOP-BT5NAMU2; Initial Catalog=AdventureWorks2019;User ID=carlos;Password=123";
        public static string ConnectionName
        {
            get => conName;
        }
    }
}
