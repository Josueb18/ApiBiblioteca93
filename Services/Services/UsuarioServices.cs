using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi93.Context;
using WebApi93.Services.IServices;

namespace WebApi93.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;

        //Cracion de un constructor

        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }
        //Lista de usuarios
        public async Task<Response<List<Usuario>>> ObtenerUsuarios() 
        
        {   try
            {
                List<Usuario> response = await _context.Usuarios.Include(y => y.Roles).ToListAsync();

                return new Response<List<Usuario>>(response);

            }

        catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

        //obtener usuario

        public async Task<Response<Usuario>> ById(int id)
        {
            try
            {
                Usuario usuario = _context.Usuarios.Find(id);

                return new Response<Usuario>(usuario);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }




        public async Task<Response<Usuario>> Crear(UsuarioResponse request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    User = request.User,
                    Password = request.Password,
                    FkRol = request.FkRol
                };
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario);
            }
            catch (Exception ex) 
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }


           

           

        }
        public async Task<Response<bool>> Eliminar(int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response<bool>("Usuario no encontrado");
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return new Response<bool>(true, "Usuario eliminado correctamente");
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }
        public async Task<Response<Usuario>> Actualizar(int id, UsuarioResponse request)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                {
                    return new Response<Usuario>("Usuario no encontrado");
                }

                usuario.Nombre = request.Nombre;
                usuario.User = request.User;
                usuario.Password = request.Password;
                usuario.FkRol = request.FkRol;

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario, "Usuario actualizado correctamente");
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }

    }
}
