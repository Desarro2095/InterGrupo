using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppInterGrupoAPI.Models;
using AppInterGrupoDAO;
using AppInterGrupoServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppInterGrupoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesController : Controller
    {
        [HttpGet("GetSalesHeader")]
        public IActionResult Get()
        {
            return Ok(InterGrupoOperation.SalesOperations().GetSalesOrderHeader());
        }

        [HttpGet("GetSalesHeaderById")]
        public IActionResult GetById([FromQuery] int salesOrderID)
        {
            return Ok(InterGrupoOperation.SalesOperations().GetSalesOrderHeaderBySalesOrderID(salesOrderID));
        }

        [HttpPost("UpdateSalesHeader")]
        public IActionResult Update(SalesOrderModel salesOrderModel)
        {
            return Ok(InterGrupoOperation.SalesOperations().UpdateSalesOrderHeader(salesOrderModel.SalesOrderID, salesOrderModel.Comment));
        }
    }
}
