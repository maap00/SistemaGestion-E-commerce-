using SistemaGestion.Database;
using SistemaGestion.Models;
using SistemaGestion.DTOs;
using SistemaGestion.Mapper;

namespace SistemaGestion.SistemaGestionBussiness
{
    public class UserService
    {
        private CoderContext context;

        public UserService(CoderContext coderContext)
        {
            this.context = coderContext;
        }

        public List<Usuario> GetAllUserList()
        {
            return this.context.Usuarios.ToList();
        }
        //NOTA: Metodo LinkQ
        public Usuario GetUserforID(int id)
        {
            //Variable que recibe un entero y retorna un string
            //Func<int, string> func = (numero) => "Hola";

            Usuario? findUserForID = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();

            return findUserForID;

        }

        //public  Usuario GetUserForID(int id)
        //{
        //    List<Usuario> users = GetAllUserList();

        //    foreach(Usuario user in users)
        //    {
        //        if(user.Id == id)
        //        {
        //            return user;
        //        }
        //    }
        //    return null;
        //}

        public bool AddNewUser(UsersDTO dto)
        {

            Usuario user = UserMapper.MapperToUser(dto);
            this.context.Usuarios.Add(user);
            context.SaveChanges();
            return true;
        }

        public bool DeleteUser(int id)
        {


            //NOTAS: Ejemplo de como eliminar un dato que comparte id con otra tabla a partir de una clave fornea FK(Eliminacion en cascada)
            //Mejor practica es con una Eliminado Logico que consiste en agregar una fecha de alta y una fecha de cierre del dato. 
            //Si el campo de fecha esta lleno entonces el codigo no toma ese dato
            //Usuario userToDelete = context.Usuarios.Include(up=> up.Productos).Where(u => u.Id == id).FirstOrDefault();

            Usuario? userToDelete = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();

            if (userToDelete != null)
            {
                context.Usuarios.Remove(userToDelete);
                context.SaveChanges();
                return true;
            }
            return false;

        }

        public bool UpdateUserForId(int id, UsersDTO usersDTO)
        {

            //signo ? indica que el valor por defecto puede ser nulo
            Usuario? userFound = context.Usuarios.Where(u => u.Id == id).FirstOrDefault();

            if (userFound != null)
            {

                userFound.Nombre = usersDTO.Nombre;
                userFound.Apellido = usersDTO.Apellido;
                userFound.NombreUsuario = usersDTO.NombreUsuario;
                userFound.Contraseña = usersDTO.Contraseña;
                userFound.Mail = usersDTO.Mail;

                context.Usuarios.Update(userFound);

                context.SaveChanges();
                return true;
            }
            return false;

        }


        public Usuario GetUserForUserNameAndPassword(string userName, string password)
        {
            List<Usuario> usersList = GetAllUserList();

            Usuario? UserLogged = usersList.Find(u => u.NombreUsuario == userName && u.Contraseña == password);

            if (UserLogged == null)
            {
                return null;
            }
            return UserLogged;
        }

    }
}
