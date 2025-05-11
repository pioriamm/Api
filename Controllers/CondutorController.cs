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

            var listaMotorista = _context.Motoristas?.ToList().Select(motorista => new{  motorista.MotoristaID, 
                motorista.DisplayName, motorista.Telefone, motorista.Login, motorista.isAdim });

            if (listaMotorista == null || !listaMotorista.Any())
            {
                return NotFound("Nenhuma motorista encontrado no banco.");
            }

            return Ok(listaMotorista);
        }

        [HttpPost("atualizarCondutor")]
        public ActionResult<Motorista> atualizarCondutor([FromBody] Motorista motoristaAtualizado)

        {
            if (motoristaAtualizado == null) return BadRequest(new { erro = "É preciso passar os dados para se editado" });

            var motoristaBanco = _context.Motoristas.FirstOrDefault(m => m.MotoristaID == motoristaAtualizado.MotoristaID);

            if (motoristaBanco == null)
            {
                return NotFound("Nenhuma motorista encontrado no banco.");
            }
            motoristaBanco.DisplayName = motoristaAtualizado.DisplayName?.ToUpper();
            motoristaBanco.Login = $"{motoristaAtualizado.DisplayName?.Split(' ')[0]}@novohorizonte.com.br";
            motoristaBanco.PassWord = motoristaAtualizado.PassWord;
            motoristaBanco.Telefone = Regex.Replace(motoristaAtualizado.Telefone, @"[\s\+\-]", "");
            motoristaBanco.isAdim = motoristaAtualizado.isAdim;

            _context.SaveChanges();

            return Ok(motoristaBanco);
        }

    }
}
