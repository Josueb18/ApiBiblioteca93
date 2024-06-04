using Domain.Entities;

namespace WebApi93.Services.IServices
{
    public interface IUsuarioServices
    {
        public Task<Response<List<Usuario>>> ObtenerUsuarios();

        public Task<Response<Usuario>> Crear(UsuarioResponse request);
        public Task<Response<bool>> Eliminar(int id);
        public Task<Response<Usuario>> Actualizar(int id, UsuarioResponse request);
        public Task<Response<Usuario>> ById(int id);
    }
}
