using Api.Context;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Api.Controllers
{
    public class CondutorController : Controller
    {
        private readonly AppDbContext _context;

        public CondutorController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost("criarCondutor")]
        public ActionResult<Motorista> CriarNovoCondutor([FromBody] Motorista motorista)
        {
            if (motorista == null)
                return BadRequest(new { erro = "É preciso passar os dados do novo Condutor" });

            if (_context?.Motoristas == null)
                return StatusCode(500, new { erro = "Erro interno: Contexto do banco de dados não está disponível." });

            var novoMotorista = new Motorista
            {
                DisplayName = motorista.DisplayName?.ToUpper(),
                Login = $"{motorista.DisplayName?.Split(' ')[0]}@novohorizonte.com.br",
                PassWord = motorista.PassWord,
                Telefone =  Regex.Replace(motorista.Telefone, @"[\s\+\-]", ""),
                isAdim = false
            };

            _context.Motoristas.Add(novoMotorista);
            _context.SaveChanges();

            return CreatedAtAction(nameof(CriarNovoCondutor), new { id = motorista.MotoristaID }, new { usuarioCriado = true });
        }

        [HttpGet ("listarCondutor")]
        public ActionResult<IEnumerable<Motorista>> listarTodosMotoristas()
        {

            var listaMotorista = _context.Motoristas?.ToList().Select(motorista => new{ motorista.DisplayName, motorista.MotoristaID });

            if (listaMotorista == null || !listaMotorista.Any())
            {
                return NotFound("Nenhuma motorista encontrado no banco.");
            }

            return Ok(listaMotorista);
        }

    }
}
