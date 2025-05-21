using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tria_2025.Connection;
using Tria_2025.Models;

namespace Tria_2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoController : ControllerBase
    {
        public readonly AppDbContext _context;

        public MotoController (AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moto>>> Get()
        {
            return await _context.Motos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Moto>> Get(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
            {
                return NotFound();
            }

            return Ok(moto);
        }

        [HttpGet("ano/{ano}")]
        public async Task<ActionResult<List<Moto>>> BuscarMotosAcimaDoAno(int ano)
        {
            var motos = await _context.Motos.Where(m => (m.Ano >= ano)).ToListAsync();
            if (motos.Count == 0)
            {
                return NotFound($"Nenhuma moto do ano {ano} ou superior foi encontrada.");
            }
            return Ok(motos);
        }

        [HttpGet("placa/{placa}")]
        public async Task<ActionResult<Moto>> BuscarPorPlaca(string placa)
        {
            var moto = await _context.Motos.FirstOrDefaultAsync(m => m.Placa == placa);
            if (moto == null)
            {
                return NotFound("Nenhuma moto registrada com a placa informada.");
            }

            return moto;
        }

        [HttpGet("modelo/{modelo}")]
        public async Task<ActionResult<List<Moto>>> BuscarPorModelo(string modelo)
        {
            var motos = await _context.Motos.Where(m => m.Modelo.ToLower() == modelo.ToLower()).ToListAsync();
            if (motos.Count == 0)
            {
                return NotFound("Nenhuma moto com o modelo informado.");
            }

            return Ok(motos);
        }
        [HttpPut("{idPassado}")]
        public async Task<ActionResult> Put(int idPassado, Moto moto)
        {
            if (moto.Id != idPassado)
            {
                return BadRequest("ID da url é diferente da url passada no corpo.");
            }

            var motoBuscada = await _context.Motos.FindAsync(idPassado);
            if (motoBuscada == null)
            {
                return NotFound($"Não foi possivel encontrar uma moto com o id {idPassado}");
            }

            if (moto.Placa != null)
                motoBuscada.Placa = moto.Placa;

            if (moto.Modelo != null)
                motoBuscada.Modelo = moto.Modelo;


            if (moto.TipoCombustivel != null)
                motoBuscada.TipoCombustivel = moto.TipoCombustivel;

            motoBuscada.IdFilial = moto.IdFilial;
            motoBuscada.Ano = moto.Ano;



            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Moto moto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(moto);
            }

            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = moto.Id }, moto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null) return NotFound($"Não fói possível encontrar uma moto com o id {id}");

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
