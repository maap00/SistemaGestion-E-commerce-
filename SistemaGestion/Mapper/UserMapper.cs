using SistemaGestion.Models;
using SistemaGestion.DTOs;

namespace SistemaGestion.Mapper
{
    public class UserMapper
    {
        public static Usuario MapperToUser(UsersDTO dto)
        {
            Usuario u = new Usuario();
            u.Id = dto.Id;
            u.Nombre = dto.Nombre;
            u.Apellido = dto.Apellido;
            u.NombreUsuario = dto.NombreUsuario;
            u.Contraseña = dto.Contraseña;
            u.Mail = dto.Mail;

            return u;
        }

        public static UsersDTO MapperToDto(Usuario user)
        {
            UsersDTO dto = new UsersDTO();
            dto.Id = user.Id;
            dto.Nombre = user.Nombre;
            dto.Apellido = user.Apellido;
            dto.NombreUsuario = user.NombreUsuario;
            dto.Contraseña = user.Contraseña;
            dto.Mail = user.Mail;

            return dto;

        }
    }
}
