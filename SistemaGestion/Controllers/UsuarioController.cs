using Microsoft.AspNetCore.Mvc;
using SistemaGestion.DTOs;
using SistemaGestion.Models;
using SistemaGestion.SistemaGestionBussiness;
using System.Net;

namespace SistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private UserService userService;


        public UsuarioController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("ListUsers")]
        public List<Usuario> GetAllUserList()
        {
            List<Usuario> list = userService.GetAllUserList();

            return list;
        }


        [HttpGet("listUsers/{id}")]
        public ActionResult<Usuario> GetUserforID(int id)
        {
            List<Usuario> list = userService.GetAllUserList();

            if (id < 0)
            {
                return BadRequest(new { mensaje = $"El numero no puede ser negativo", status = HttpStatusCode.Conflict });
            }

            return userService.GetUserforID(id);
        }

        [HttpGet("{userName}/{password}")]
        public ActionResult<Usuario> GetUserForUserNameAndPassword(string userName, string password)
        {
            Usuario List = userService.GetUserForUserNameAndPassword(userName, password);
            if (List == null)
            {
                return BadRequest(new { mensaje = $"El usuario no extise o los datos son incorrectos", status = 400 });
            }
            return userService.GetUserForUserNameAndPassword(userName, password);

        }

        //[FromBody] decotativo para indicar que va un parametro
        //UsersDTO es un objeto de transferencia que omite los campos de la tabla que estan relacionado con otras tablas
        [HttpPost]
        public IActionResult AddNewUser([FromBody] UsersDTO usersDTO)
        {
            try
            {
                this.userService.AddNewUser(usersDTO);
                return base.Ok(new { mensaje = "Usuario agregado", usersDTO });

            }
            catch (Exception ex)
            {
                return base.Conflict(new { mensaje = "No se agrego el usuario" });
            }

        }

        [HttpDelete("deleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {

            if (id > 0)
            {
                if (this.userService.DeleteUser(id))
                {
                    return base.Ok(new { mensaje = "Usuario eliminado", status = HttpStatusCode.OK });
                }
                else
                {
                    return base.Conflict(new { mensaje = "No se pudo borrar el producto, puede que el id no exista" });
                }
            }
            return BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });

        }

        [HttpPut]

        public IActionResult UpdateUserForId(int id, [FromBody] UsersDTO usersDTO)
        {
            if (id > 0)
            {
                if (this.userService.UpdateUserForId(id, usersDTO))
                {
                    return base.Ok(new { mensaje = "Usuario actualizado", estatus = 200, usersDTO });
                }
                return base.Conflict(new { mensaje = "No se pudo actualizar el producto, puede que el id no exista" });
            }
            return BadRequest(new { status = 400, mensaje = "El id no puede ser negativo" });
        }



    }
}
