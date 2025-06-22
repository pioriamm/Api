using Api.Context;
using Api.Models.DTO;
using Api.Models.Entity;
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
                motorista.celularId,
                motorista.perfilAcesso
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
                Login = $"{motorista.DisplayName?.Split(' ')[0]}@nhl.com.br",
                PassWord = motorista.PassWord,
                Telefone =  Regex.Replace(motorista.Telefone, @"[\s\+\-]", ""),
                perfilAcesso = motorista.perfilAcesso,
                celularId = motorista.celularId
            };

            _context.Motoristas.Add(novoMotorista);
            _context.SaveChanges();

            return CreatedAtAction(nameof(criarNovoMotorista), new { id = motorista.Id }, new { usuarioCriado = true });
        }

        

        [HttpPost("atualizarMotorista")]
        public ActionResult<MotoristaDto> atualizarCondutor([FromBody] MotoristaDto motoristaAtualizado)

        {
            if (motoristaAtualizado == null) return BadRequest(new { erro = "É preciso passar os dados para se editado" });            

            var motoristaBanco = _context.Motoristas.FirstOrDefault(m => m.Id == motoristaAtualizado.id);

            if (motoristaBanco == null) return NotFound("Nenhuma motorista encontrado no banco.");

            motoristaBanco.DisplayName = motoristaAtualizado.DisplayName;
            motoristaBanco.Login = $"{motoristaAtualizado.DisplayName?.Split(' ')[0]}nhl.com.br";
            motoristaBanco.Telefone = Regex.Replace(motoristaAtualizado.Telefone, @"[\s\+\-]", "");
            motoristaBanco.perfilAcesso = motoristaAtualizado.perfilAcesso;

            _context.SaveChanges();
            return Ok(motoristaBanco);
        }

    }
}
