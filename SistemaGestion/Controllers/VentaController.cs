using Microsoft.AspNetCore.Mvc;
using SistemaGestion.DTOs;
using SistemaGestion.Models;
using SistemaGestion.SistemaGestionBussiness;
using System.Net;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private SalesServices salesServices;

        public VentaController(SalesServices salesServices)
        {
            this.salesServices = salesServices;
        }

        [HttpGet("ListSales")]
        public List<Ventum> GetAllSalesList()
        {
            List<Ventum> list = salesServices.GetAllSalesList();

            return list;
        }

        [HttpPost]
        public IActionResult AddNewSale([FromBody]SalesDTO salesDTO) {
            if (this.salesServices.AddNewSale(salesDTO))
            {
                return base.Ok(new { mensaje = "Venta agregada", salesDTO });

            }
            else
            {
                return base.Conflict(new { mensaje = "No se agrego la venta" });
            }
        }

        [HttpGet("listSales/{id}")]
        public  List<Ventum> GetSalesforID(int id)
        {                 
            return salesServices.GetSalesforID(id);
        }


    }
}
