using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tria_2025.Connection;
using Tria_2025.Models;

namespace Tria_2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilialController : ControllerBase
    {
        public readonly AppDbContext _context;

        public FilialController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filial>>> Get()
        {
            return await _context.Filiais.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Filial>> BuscarPorId(int id)
        {
            var filial = await _context.Filiais.FindAsync(id);
            if (filial == null)
            {
                return NotFound();
            }

            return filial;
        }

        [HttpGet("/nome/{nomeFilial}")]
        public async Task<ActionResult<List<Filial>>> BuscarPorNome(string nomeFilial)
        {
            var filiais = await _context.Filiais.Where(c => c.Nome.ToLower().Contains(nomeFilial.ToLower())).ToListAsync();
            if (filiais.Count == 0)
            {
                return NotFound();
            }

            return filiais;
        }

        [HttpPut("{idPassado}")]
        public async Task<ActionResult> Put(int idPassado, Filial filial)
        {
            if (filial.Id != idPassado)
            {
                return BadRequest("ID da url é diferente da url passada no corpo.");
            }

            var filialBuscada = await _context.Filiais.FindAsync(idPassado);
            if (filialBuscada == null)
            {
                return NotFound($"Não foi possivel encontrar uma filial com o id {idPassado}");
            }

            if (filial.Nome != null)
                filialBuscada.Nome = filial.Nome;

            if (filial.IdEndereco != null)
                filialBuscada.IdEndereco = filial.IdEndereco;


            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Filial filial)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(filial);
            }

            _context.Filiais.Add(filial);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = filial.Id }, filial);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filial = await _context.Filiais.FindAsync(id);
            if (filial == null) return NotFound($"Não fói possível encontrar uma filial com o id {id}");

            _context.Filiais.Remove(filial);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
