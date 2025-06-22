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
    public ActionResult Get([FromQuery] string login, [FromQuery] string senha, [FromQuery] string idCelular)
    {
        try
        {
            var motorista = _context.Motoristas?.FirstOrDefault(m => m.Login.ToLower() == login.ToLower() && m.PassWord == senha);

            if (motorista == null)
            {
                return NotFound(new
                {
                    status = "400",
                    erro = "",
                    motorista = new { }
                });
            }

            motorista.celularId = idCelular;
            _context.Motoristas.Update(motorista);
            _context.SaveChanges();

            return Ok(new
            {
                status = "200",
                erro = (string?)null,
                motorista = new
                {           
                   
                    motorista.Id,
                    motorista.DisplayName,
                    motorista.perfilAcesso,
                    motorista.Login,
                    motorista.Telefone,
                    motorista.celularId,
                }
            });
        }
        catch (Exception e)
        {
            return BadRequest(new
            {
                status = "500",
                erro = e.Message,
                motorista = new { }
            });
        }
    }


}