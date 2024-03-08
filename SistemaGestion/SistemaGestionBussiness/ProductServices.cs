using SistemaGestion.Database;
using SistemaGestion.Models;
using SistemaGestion.SistemaGestionBussiness;
using SistemaGestion.DTOs;
using SistemaGestion.Mapper;

namespace SistemaGestion.SistemaGestionBussiness
{ 
        public class ProductServices
        {

            private CoderContext context;

            public ProductServices(CoderContext coderContext)
            {
                this.context = coderContext;
            }


            public  List<Producto> GetAllProductsList()
            {
            List<Producto> products = context.Productos.ToList();

                return products;
            }

            public List<Producto> GetProductForID(int id)
            {

            List<Producto> productsList = GetAllProductsList();

            //List<Producto> productForIdUser = new List<Producto>();

            List <Producto> productsListforID = context.Productos.Where(u => u.IdUsuario == id).ToList();

            //foreach (Producto product in productsList)
            //{
            //    if (product.IdUsuario == id)
            //    {
            //        return productForIdUser.Add(product);   
            //    }
            //}
            return productsListforID;
            }

            public bool AddNewProduct(ProductDTO dto)
            {
                Producto product = ProductMapper.MapperToProduct(dto);
                context.Productos.Add(product);
                context.SaveChanges();
                return true;
            }

            public bool DeleteProduct(int id)
            {
                Producto? productToDelete = context.Productos.Where(u => u.Id == id).FirstOrDefault();

                if (productToDelete != null)
                {
                    context.Productos.Remove(productToDelete);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }

            public bool UpdateProductForId(int id, ProductDTO productDTO)
            {

                Producto? productFound = context.Productos.Where(u => u.Id == id).FirstOrDefault();

                productFound.Descripciones = productDTO.Descripciones;
                productFound.Costo = productDTO.Costo;
                productFound.PrecioVenta = productDTO.PrecioVenta;
                productFound.Stock = productDTO.Stock;
                productFound.IdUsuario = productDTO.IdUsuario;


                context.Productos.Update(productFound);

                context.SaveChanges();
                return true;

            }
        }
    
}
