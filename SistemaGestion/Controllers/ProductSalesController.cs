using Microsoft.AspNetCore.Mvc;
using SistemaGestion.Models;
using SistemaGestion.SistemaGestionBussiness;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductSalesController : Controller
    {
        private ProductSalesServices productSalesServices;

        public ProductSalesController (ProductSalesServices productSalesServices)
        {
            this.productSalesServices = productSalesServices;
        }

        [HttpGet("/list")]
        public List<ProductoVendido> GetAllProductsList()
        {
            List<ProductoVendido> list = productSalesServices.GetSalesProductList();
            return list;
        }



        [HttpGet("ListaProductosVendidos/{idUsuario}")]
        public List<ProductoVendido> GetSaleProductforID(int idUsuario)
        {
            return productSalesServices.GetSaleProductforID(idUsuario);
        }
    }

}
