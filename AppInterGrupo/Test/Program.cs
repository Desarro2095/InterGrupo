using AppInterGrupoDAO.DAO;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            PurchaseDAO test = new PurchaseDAO();
            var pru = test.GetPurchaseOrderHeader();
            Console.ReadLine();
        }
    }
}
