using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tria_2025.Connection;
using Tria_2025.Models;

namespace Tria_2025.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotoSetorController : ControllerBase
    {
        public readonly AppDbContext _context;

        public MotoSetorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MotoSetor>>> Get()
        {
            return await _context.Moto_Setores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MotoSetor>> Get(int id)
        {
            var motoSetor = await _context.Moto_Setores.FindAsync(id);
            if (motoSetor == null)
            {
                return NotFound();
            }

            return motoSetor;
        }

        [HttpPut("{idPassado}")]
        public async Task<ActionResult> Put(int idPassado, MotoSetor motoSetor)
        {
            if (motoSetor.Id != idPassado)
            {
                return BadRequest("ID da url é diferente da url passada no corpo.");
            }

            var motoSetorBuscado = await _context.Moto_Setores.FindAsync(idPassado);
            if (motoSetorBuscado == null)
            {
                return NotFound($"Não foi possivel encontrar com o id {idPassado}");
            }

            motoSetorBuscado.Data = motoSetor.Data;
            motoSetorBuscado.IdMoto = motoSetor.IdMoto;
            motoSetorBuscado.IdSetor = motoSetor.IdSetor;

            if (motoSetor.Fonte != null)
                motoSetorBuscado.Fonte = motoSetor.Fonte;



            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post(MotoSetor motoSetor)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(motoSetor);
            }

            _context.Moto_Setores.Add(motoSetor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = motoSetor.Id }, motoSetor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var setor = await _context.Moto_Setores.FindAsync(id);
            if (setor == null) return NotFound($"Não fói possível encontrar com o id {id}");

            _context.Moto_Setores.Remove(setor);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
