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
            .Include(j => j.MotoristaID).ToList().Select(j => new
            {
                j.Id,
                j.JornadaData,
               
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
    
    [HttpGet("ListarTodasJornadasData/{dataInicio}/{dataFim}/{motorista}")]
    public ActionResult<IEnumerable<object>> ListarTodasJornadasData(DateOnly dataInicio, DateOnly dataFim,  string motorista)
    {
    
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

    
    [HttpGet("buscarJornadaPorMotoristaID/{id}")] 
    public ActionResult<IEnumerable<object>> ListarTodasJornadasPeloMotorista(Guid id)
    {
        var listaJornadas = _context.Jornadas?
            .Include(j => j.Motorista)
            .Where(j => j.MotoristaID == id)
            .Select(j => new
            {
                j.Id,
                j.JornadaData,            
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
    

    [HttpGet("buscarJornadaPorID/{id}")] 
    public ActionResult<Jornada> ObterJornadaPeloId(Guid id )
    {
        var jornada = _context.Jornadas?
            .Include(j => j.Motorista)
            .FirstOrDefault(j => j.Id == id);;
        
        if (jornada == null)
        {
            return NotFound();
        }
        return Ok(new
        {
            jornada.Id,
            jornada.JornadaData,       
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
            .FirstOrDefault(j => j.Id == id);;
        
        if (jornada == null)
        {
            return NotFound();
        }
        return Ok(new
        {
            jornada.Id,
            jornada.JornadaData,          
            jornada.MotoristaID,
            jornada.Motorista?.Telefone,
            jornada.Placa,
            jornada.Km
        });
    }
    

    [HttpPost("criarNovaJornada")]
    public ActionResult<JornadaUpdateDto> RegistrarNovaJornada([FromBody] JornadaUpdateDto jornadaDto)
    {
        if (jornadaDto == null) return BadRequest();

 
        var jornada = new Jornada
        {
            Id = jornadaDto.Id,
            JornadaData = jornadaDto.JornadaData,
            JornadaLocalidade = jornadaDto.JornadaLocalidade.ToUpper(),
            MotoristaID = jornadaDto.MotoristaID,
            Placa = jornadaDto.Placa.ToUpper(),
            Km = jornadaDto.Km
        };

        _context.Jornadas?.Add(jornada);
        _context.SaveChanges();

        return Ok(jornadaDto);
    }

    [HttpPost("atualizarJornada")]
    public ActionResult<JornadaUpdateDto> AtualizarJornada([FromBody] JornadaUpdateDto jornadaDto)
    {
        if (jornadaDto == null)
            return BadRequest("Dados inválidos.");

        var jornada = _context.Jornadas.FirstOrDefault(j => j.Id == jornadaDto.Id);

        if (jornada == null)     return NotFound("Jornada não encontrada.");

        jornada.Placa = jornadaDto.Placa;
        jornada.Km = jornadaDto.Km;
        jornada.MotoristaID = jornadaDto.MotoristaID;
        jornada.JornadaData = jornadaDto.JornadaData;
        jornada.JornadaLocalidade = jornadaDto.JornadaLocalidade;
        _context.SaveChanges();

        return Ok(jornadaDto);
    }



    [HttpGet("auditoria/{dataInicio}/{dataFim}/{motorista}")]
    public ActionResult<double> Auditoria(DateTime dataInicio, DateTime dataFim, string motorista)
    {
        if (string.IsNullOrEmpty(motorista))
            return BadRequest("Parâmetros inválidos.");

        if (!Guid.TryParse(motorista, out Guid motoristaId))
            return BadRequest("ID do motorista inválido.");

        var jornadaFiltrada = _context.Jornadas
            .Where(jornada => jornada.JornadaData >= DateOnly.FromDateTime(dataInicio)
                              && jornada.JornadaData <= DateOnly.FromDateTime(dataFim)
                              && jornada.MotoristaID == motoristaId)
            .Sum(jornada => jornada.Km);

        return Ok(jornadaFiltrada);
    }



}