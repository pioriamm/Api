namespace Api.Controllers;
using Microsoft.AspNetCore.Mvc; 
using Api.Context;
using Api.Models;


[ApiController]
[Route("[controller]")]

public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet("credenciais")]
    public ActionResult<Motorista> Get([FromQuery] string login, [FromQuery] string senha)
    {
        var motorista = _context.Motoristas?.FirstOrDefault(m => m.Login == login && m.PassWord == senha);

        if (motorista == null)
        {
            return NotFound(new { mensagem = "Credenciais inválidas" });
        }

        return Ok(new { motorista.Login, motorista.Telefone, motorista.DisplayName, motorista.Id, motorista.isAdim});
    }

}