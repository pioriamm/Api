using Microsoft.AspNetCore.Mvc;
using Api.Context;
using Api.Models;
using Microsoft.CodeAnalysis;
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

    [HttpGet("listarTodasJornadas")]
    public ActionResult<IEnumerable<Jornada>> ListarTodasJornadas()
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
            return NotFound("Nenhuma jornada encontrada no banco.");
        }

        return Ok(listaJornadas);
    }
    
    [HttpGet("ListarTodasJornadasData/{motorista}")]
    public ActionResult<IEnumerable<object>> ListarTodasJornadasData(string motorista)
    {
        var hoje = DateTime.Now;
        var dataInicio = new DateOnly(hoje.Year, hoje.Month-1, 20);
        var dataFim = DateOnly.FromDateTime(DateTime.Now);
    
        if (string.IsNullOrEmpty(motorista))
            return BadRequest("Parâmetros inválidos.");

        if (!Guid.TryParse(motorista, out Guid motoristaId))
            return BadRequest("ID do motorista inválido.");

        var jornadaFiltrada = _context.Jornadas
            .Where(jornada => jornada.JornadaData >= dataInicio 
                              && jornada.JornadaData <= dataFim 
                              && jornada.MotoristaID == motoristaId)
            .ToList();

        return Ok(jornadaFiltrada);
    }

    
    [HttpGet("porMotoristaID/{id}")] 
    public ActionResult<IEnumerable<object>> ListarTodasJornadasPeloMotorista(Guid id)
    {
        var listaJornadas = _context.Jornadas?
            .Include(j => j.Motorista)
            .Where(j => j.MotoristaID == id)
            .Select(j => new
            {
                j.QuilometragemId,
                j.JornadaData,
                JornadaHora = j.JornadaHora.ToString("HH:mm:ss"),
                j.MotoristaID,
                j.Motorista.DisplayName,
                j.Motorista.Telefone,
                j.Placa,
                j.Km
            })
            .ToList();

        if (listaJornadas == null || !listaJornadas.Any())
        {
            return NotFound();
        }

        return Ok(listaJornadas);
    }
    
    

    [HttpGet("porID/{id}")] 
    public ActionResult<Jornada> ObterJornadaPeloId(Guid id )
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
    public ActionResult<Jornada> MostrarNovaJornada(Guid id )
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
    

    [HttpPost ("criarNovaJornada")]
    public ActionResult<Jornada> RegistrarNovaJornada([FromBody] Jornada jornada)
    {
        if (jornada == null) return BadRequest();
        
        _context.Jornadas?.Add(jornada);
        _context.SaveChanges();
        
        return Ok(jornada);
    }


    [HttpGet("auditoria/{dataInicio}/{dataFim}/{motorista}")]
    public ActionResult<double> Auditoria(DateOnly dataInicio, DateOnly dataFim, string motorista)
    {
        if (string.IsNullOrEmpty(motorista))
            return BadRequest("Parâmetros inválidos.");

        if (!Guid.TryParse(motorista, out Guid motoristaId))
            return BadRequest("ID do motorista inválido.");

        var jornadaFiltrada = _context.Jornadas
            .Where(jornada => jornada.JornadaData >= dataInicio 
                              && jornada.JornadaData <= dataFim 
                              && jornada.MotoristaID == motoristaId)
            .Sum(jornada => jornada.Km);

        return Ok(jornadaFiltrada);
    }



}