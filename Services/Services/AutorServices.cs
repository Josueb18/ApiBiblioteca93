using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Data;
using WebApi93.Context;
using WebApi93.Services.IServices;


namespace WebAPI93.Services.Services
{
    public class AutoresServices : IAutorServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;

        //Constructor
        public AutoresServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> response = new List<Autor>();

                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new { }, commandType: CommandType.StoredProcedure);

                response = result.ToList();

                return new Response<List<Autor>> (response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error:" + ex.Message);
            }
        }

        public async Task<Response<Autor>> Crear(Autor i)
        {
            try
            {
                Autor autor = new Autor();

                var response = await _context.Database.GetDbConnection().QueryAsync<Autor>("SpCrearAutor", new {i.Nombre,i.Nacionalidad}, commandType: CommandType.StoredProcedure);

                foreach (var item in response)
                {
                    autor.Nombre = item.Nombre;
                    autor.Nacionalidad = item.Nacionalidad;
                }

                return new Response<Autor>(autor);


            } 
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error :(" + ex.Message);
            }
        }




    }
}