using SistemaGestion.DTOs;
using SistemaGestion.Models;

namespace SistemaGestion.Mapper
{
    public class ProductMapper
    {
        public static Producto MapperToProduct(ProductDTO productDTO)
        {
            Producto p = new Producto();
            p.Descripciones = productDTO.Descripciones;
            p.Costo = productDTO.Costo;
            p.PrecioVenta = productDTO.PrecioVenta;
            p.Stock = productDTO.Stock;
            p.IdUsuario = productDTO.IdUsuario;

            return p;
        }

        public static ProductDTO MapperToDto(Producto product)
        {
            ProductDTO dto = new ProductDTO();
            dto.Descripciones = product.Descripciones;
            dto.Costo = product.Costo;
            dto.PrecioVenta = product.PrecioVenta;
            dto.Stock = product.Stock;
            dto.IdUsuario = product.IdUsuario;

            return dto;
        }

    }
}
