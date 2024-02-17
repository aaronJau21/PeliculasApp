using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Dtos;
using Model.Entity;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {

        private readonly ApplicationDbContext _db;

        public PeliculaController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetUsuarios()
        {
            var peliculas = await _db.Peliculas.ToListAsync();

            return Ok(peliculas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>> GetPelicula(int id)
        { 
            var pelicula = await _db.Peliculas.FindAsync(id);

            return Ok(pelicula);
        }

        [HttpPost]
        public async Task<ActionResult<Pelicula>> CreatePelicula(PeliculaDto peliculaDto)
        {
            if (await PeliculaExiste(peliculaDto.Titulo)) return BadRequest("Ya existe la película");

            var pelicula = new Pelicula 
            {
                Titulo = peliculaDto.Titulo,
                Sinopsis = peliculaDto.Sinopsis,
                Genero = peliculaDto.Genero,
                Duracion = peliculaDto.Duracion,
                HorarioInicio = peliculaDto.HorarioInicio,
                HorarioFin = peliculaDto.HorarioFin,
                Imagen = peliculaDto.Imagen,
                SalasDisponibles = peliculaDto.SalasDisponibles,
                EntradasDisponibles = peliculaDto.EntradasDisponibles
            };

            _db.Peliculas.Add(pelicula);
            await _db.SaveChangesAsync();
            return pelicula;

        }

        private async Task<bool> PeliculaExiste(string titulo)
        {
            return await _db.Peliculas.AnyAsync(x => x.Titulo == titulo);
        }

    }
}
