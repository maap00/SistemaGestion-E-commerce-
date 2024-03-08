using SistemaGestion.DTOs;
using SistemaGestion.Models;

namespace SistemaGestion.Mapper
{
    public class SalesMapper
    {
        public static Ventum MapperToSales(SalesDTO salesDTO)
        {
            Ventum v = new Ventum();
            v.Id = salesDTO.Id;
            v.Comentarios = salesDTO.Comentarios; 
            v.IdUsuario = salesDTO.IdUsuario; 
            return v;
        }

        public static SalesDTO MapperToDto(Ventum ventum)
        {
            SalesDTO dto = new SalesDTO();
            dto.Id = ventum.Id;  
            dto.Comentarios = ventum.Comentarios;
            dto.IdUsuario = ventum.IdUsuario;        
            return dto;
        }
    }
}
