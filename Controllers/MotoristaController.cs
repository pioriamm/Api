using Api.Context;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Api.Controllers
{
    public class MotoristaController : Controller
    {
        private readonly AppDbContext _context;

        public MotoristaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("listarMotorista")]
        public ActionResult<IEnumerable<Motorista>> listarTodosMotoristas()
        {

            var listaMotorista = _context.Motoristas?.ToList().Select(motorista => new {
                motorista.Id,
                motorista.DisplayName,
                motorista.Telefone,
                motorista.Login,
                motorista.isAdim
            });

            if (listaMotorista == null || !listaMotorista.Any())
            {
                return NotFound("Nenhuma motorista encontrado no banco.");
            }

            return Ok(listaMotorista);
        }



        [HttpPost("criarMotorista")]
        public ActionResult<Motorista> criarNovoMotorista([FromBody] Motorista motorista)
        {
            if (motorista == null)  return BadRequest(new { erro = "É preciso passar os dados do novo Condutor" });

            if (_context?.Motoristas == null)
                return StatusCode(500, new { erro = "Erro interno: Contexto do banco de dados não está disponível." });

            var novoMotorista = new Motorista
            {
                DisplayName = motorista.DisplayName,
                Login = motorista.Login,
                PassWord = motorista.PassWord,
                Telefone =  Regex.Replace(motorista.Telefone, @"[\s\+\-]", ""),
                isAdim = motorista.isAdim,
                celularId = motorista.celularId
            };

            _context.Motoristas.Add(novoMotorista);
            _context.SaveChanges();

            return CreatedAtAction(nameof(criarNovoMotorista), new { id = motorista.Id }, new { usuarioCriado = true });
        }

        

        [HttpPost("atualizarMotorista")]
        public ActionResult<Motorista> atualizarCondutor([FromBody] Motorista motoristaAtualizado)

        {
            if (motoristaAtualizado == null) return BadRequest(new { erro = "É preciso passar os dados para se editado" });

            var motoristaBanco = _context.Motoristas.FirstOrDefault(m => m.Id == motoristaAtualizado.Id);

            if (motoristaBanco == null) return NotFound("Nenhuma motorista encontrado no banco.");
     
            motoristaBanco.DisplayName = motoristaAtualizado.DisplayName;
            motoristaBanco.Login = motoristaAtualizado.Login;
            motoristaBanco.PassWord = motoristaAtualizado.PassWord;
            motoristaBanco.Telefone = Regex.Replace(motoristaAtualizado.Telefone, @"[\s\+\-]", "");
            motoristaBanco.isAdim = motoristaAtualizado.isAdim;
            motoristaBanco.celularId = motoristaAtualizado.celularId;
            _context.SaveChanges();
            return Ok(motoristaBanco);
        }

    }
}
