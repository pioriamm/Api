using Microsoft.AspNetCore.Mvc;
using Api.Context;
using Api.Models;
using Microsoft.EntityFrameworkCore;


namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class JornadaController : ControllerBase
{
    private readonly AppDbContext _context;

    public JornadaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<object>> Get()
    {
        var listaJornadas = _context.Jornadas?
            .Include(j => j.Motorista).ToList().Select(j => new
            {
                j.QuilometragemId,
                j.JornadaData,
                JornadaHora = j.JornadaHora.ToString("HH:mm:ss"),
                j.MotoristaID,
                j.Motorista.DisplayName,
                j.Motorista.Telefone,
                j.Placa,
                j.Km
            });

        if (listaJornadas == null || !listaJornadas.Any())
        {
            return NotFound();
        }

        return Ok(listaJornadas);
    }

    [HttpGet("porID/{id}")] 
    public ActionResult<Jornada> Get(Guid id )
    {
        var jornada = _context.Jornadas?
            .Include(j => j.Motorista)
            .FirstOrDefault(j => j.QuilometragemId == id);;
        
        if (jornada == null)
        {
            return NotFound();
        }
        return Ok(new
        {
            jornada.QuilometragemId,
            jornada.JornadaData,
            jornada.JornadaHora,
            jornada.MotoristaID,
            jornada.Motorista?.DisplayName,
            jornada.Placa,
            jornada.Km
        });
    }
    
    [HttpGet("nova-jornada/{id}", Name = "GetNovaJornada")]
    public ActionResult<Jornada> GetNovaJornada(Guid id )
    {
        var jornada = _context.Jornadas?
            .Include(j => j.Motorista)
            .FirstOrDefault(j => j.QuilometragemId == id);;
        
        if (jornada == null)
        {
            return NotFound();
        }
        return Ok(new
        {
            jornada.QuilometragemId,
            jornada.JornadaData,
            jornada.JornadaHora,
            jornada.MotoristaID,
            jornada.Motorista?.Telefone,
            jornada.Placa,
            jornada.Km
        });
    }
    

    [HttpPost]
    public ActionResult<Jornada> Post([FromBody] Jornada jornada)
    {
        if (jornada == null) return BadRequest();
        
        _context.Jornadas?.Add(jornada);
        _context.SaveChanges();
        
        return CreatedAtRoute("GetNovaJornada", new { id = jornada.QuilometragemId }, jornada);
    }
}