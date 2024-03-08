using SistemaGestion.Database;
using SistemaGestion.DTOs;
using SistemaGestion.Mapper;
using SistemaGestion.Models;
using SistemaGestion.SistemaGestionBussiness;


namespace SistemaGestion.SistemaGestionBussiness
{
    public class SalesServices
    {

        private CoderContext context;

        public SalesServices(CoderContext coderContext)
        {
            this.context = coderContext;
        }


        public List<Ventum> GetAllSalesList()
        {
            List<Ventum> saleList = context.Venta.ToList();

            return saleList;
        }

        public bool AddNewSale(SalesDTO dto)
        {
            Ventum sale = SalesMapper.MapperToSales(dto);
            context.Venta.Add(sale);    
            context.SaveChanges();
            return true;
        }

        public List<Ventum> GetSalesforID(int id)
        {
            List<Ventum> saleList = GetAllSalesList();
            List <Ventum> findSalesforID = saleList.Where(v => v.IdUsuario == id).ToList();

            return findSalesforID;
        }

    }
}
