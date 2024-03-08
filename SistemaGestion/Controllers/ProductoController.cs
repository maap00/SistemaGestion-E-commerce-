using Microsoft.AspNetCore.Mvc;
using SistemaGestion.DTOs;
using SistemaGestion.Models;
using SistemaGestion.SistemaGestionBussiness;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        private ProductServices productsService;

        public ProductoController(ProductServices productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("ListProducts")]
        public List<Producto> GetAllProductsList()
        {
            List<Producto> list = productsService.GetAllProductsList();

            return list;
        }

        [HttpGet("listProducts/{id}")]
        public List<Producto> GetProductForID(int id)
        {
            List<Producto> list = productsService.GetAllProductsList();
           

            return productsService.GetProductForID(id);
        }

        [HttpPost]
        public IActionResult AddNewProduct([FromBody] ProductDTO productDTO)
        {

            if (this.productsService.AddNewProduct(productDTO))
            {
                return base.Ok(new { mensaje = "Producto agregado", productDTO });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se agrego el producto" });
            }
        }

        [HttpDelete("deleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {

            if (id > 0)
            {
                if (this.productsService.DeleteProduct(id))
                {
                    return base.Ok(new { mensaje = "Producto eliminado", status = 200 });
                }
                else
                {
                    return base.Conflict(new { mensaje = "No se pudo borrar el producto, puede que el id no exista" });
                }
            }
            return BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });

        }


        [HttpPut("updateProduct/{id}")]

        public IActionResult UpdateProductForId(int id, [FromBody] ProductDTO productDTO)
        {
            if (id > 0)
            {
                if (this.productsService.UpdateProductForId(id, productDTO))
                {
                    return base.Ok(new { mensaje = "Producto actualizado", estatus = 200, productDTO });
                }
                return base.Conflict(new { mensaje = "No se pudo actualizar el producto, puede que el id no exista" });
            }
            return BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }
    }
}
