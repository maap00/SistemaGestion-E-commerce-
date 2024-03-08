using SistemaGestion.Database;
using SistemaGestion.Models;
using SistemaGestion.SistemaGestionBussiness;



namespace SistemaGestion.SistemaGestionBussiness
{
    public class ProductSalesServices
    {

        private CoderContext context;
        public ProductSalesServices(CoderContext coderContext) {
            
            this.context = coderContext;    
        
        }


        public List<ProductoVendido> GetSalesProductList() {
        
            List<ProductoVendido> list = context.ProductoVendidos.ToList();
            return list;
        }

        public List<ProductoVendido> GetSaleProductforID(int idUser)
        {


            //List<Producto> productList = ProductServices.GetAllProductsList();
            List <Producto> findSaleForID = context.Productos.Where(p => p.IdUsuario == idUser).ToList();


            List<ProductoVendido> listSalesProduct = GetSalesProductList(); 

            List<ProductoVendido> listResult = new List<ProductoVendido>();

            foreach (Producto product in findSaleForID)
            {
                int id = product.Id;
                ProductoVendido ? listSalesForID = listSalesProduct.Find(p => p.IdProducto == id);

                if (listSalesForID is not null)
                {
                    listResult.Add(listSalesForID);
                }

            }
            return listResult;

        }

    }
}
