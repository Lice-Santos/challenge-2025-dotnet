using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tria_2025.Connection;
using Tria_2025.DTO;
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

        //[HttpGet("placa/{placa}")]
        //public async Task<ActionResult<Moto>> BuscarPorPlaca(string placa)
        //{
        //    var motoSetor = await _context.Moto_Setores
        //        .Include(ms => ms.Moto)
        //        .Include(ms => ms.Setor)
        //        .Where(ms => ms.Moto.Placa == placa)
        //        .Select(ms => new MotoSetorDto
        //        {
        //            Id = ms.Id,
        //            Data = ms.Data,
        //            Fonte = ms.Fonte,
        //            MotoPlaca = ms.Moto.Placa,
        //            MotoModelo = ms.Moto.Modelo,
        //            SetorNome = ms.Setor.Nome
        //        })
        //        .FirstOrDefaultAsync();

        //    if (motoSetor == null)
        //    {
        //        return NotFound("Nenhuma moto registrada com a placa informada.");
        //    }

        //    return motoSetor;
        //}

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, MotoSetorDto dto)
        {
            var entidade = await _context.Moto_Setores.FindAsync(id);
            if (entidade == null)
                return NotFound($"Não foi encontrado um MotoSetor com o ID {id}.");

            var moto = await _context.Motos.FindAsync(dto.IdMoto);
            var setor = await _context.Setores.FindAsync(dto.IdSetor);
            if (moto == null || setor == null)
            {
                return BadRequest("Moto ou Setor não encontrados.");
            }

            entidade.Data = dto.Data;
            entidade.Fonte = dto.Fonte;
            entidade.IdMoto = dto.IdMoto;
            entidade.IdSetor = dto.IdSetor;
            entidade.Moto = moto;
            entidade.Setor = setor;

            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult> Post(MotoSetorDto motoSetorDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var setorObjeto = await _context.Setores.FindAsync(motoSetorDto.IdSetor);
            var motoObjeto = await _context.Motos.FindAsync(motoSetorDto.IdMoto);

            if (motoObjeto == null || setorObjeto == null) {
                return BadRequest("Não foi possível encontrar o endereço passado");
            }

            var motoSetorCompleto = new MotoSetor { 
                Data = motoSetorDto.Data,
                Fonte = motoSetorDto.Fonte,
                IdMoto = motoSetorDto.IdMoto,
                IdSetor = motoSetorDto.IdSetor,
                Moto = motoObjeto,
                Setor = setorObjeto
            };


            _context.Moto_Setores.Add(motoSetorCompleto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = motoSetorCompleto.Id }, motoSetorCompleto);
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
