using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppInterGrupoDAO;
using Microsoft.AspNetCore.Mvc;

namespace AppInterGrupoAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Purchase : Controller
    {
        [HttpGet("GetPurchaseOrderHeader")]
        public IActionResult Get()
        {
            return Ok(InterGrupoOperation.PurchaseOperations().GetPurchaseOrderHeader());
        }

        [HttpGet("GetPurchaseOrderHeaderById")]
        public IActionResult GetById([FromQuery] int purchaseOrderID)
        {
            return Ok(InterGrupoOperation.PurchaseOperations().GetPurchaseOrderHeaderByPurchaseOrderID(purchaseOrderID));
        }
    }
}
