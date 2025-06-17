using Api.Context;
using Api.Models.DTO;
using Api.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Api.Controllers
{
    public class InfracoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InfracoesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("criarInfracoes")]
        public ActionResult<Infracoes> criarNovaInfracao([FromBody] Infracoes infracoes)
        {
            if (infracoes == null) return BadRequest(new { erro = "É preciso passar os dados da nova infracao" });

            if (_context?.infracoes == null)
                return StatusCode(500, new { erro = "Erro interno: Contexto do banco de dados não está disponível." });

            var novaInfracao = new Infracoes
            {
                velocidade = infracoes.velocidade,
                reclamacao = infracoes.reclamacao,
                multa = infracoes.multa,
                pequenaMonta = infracoes.pequenaMonta,
                grandeMonta = infracoes.grandeMonta,
                MotoristaId = infracoes.MotoristaId,
                entradaInfracao = infracoes.entradaInfracao,
                saidaInfracao = infracoes.saidaInfracao,

            };

            _context.infracoes.Add(novaInfracao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(novaInfracao), new { id = infracoes.infracaoId }, new { novaInfracao = true });
        }

        [HttpGet("ListarInfracoesPorPeriodo/{dataInicio}/{dataFim}/{idMotorista}")]
        public ActionResult<IEnumerable<object>> ListarInfracoesPorPeriodo(DateOnly dataInicio, DateOnly dataFim, string idMotorista)
        {

            if (string.IsNullOrEmpty(idMotorista))
                return BadRequest("Parâmetros inválidos.");

            if (!Guid.TryParse(idMotorista, out Guid motoristaId))
                return BadRequest("ID do infracao inválido.");

            var infracoesFiltradas = _context.infracoes
                .Where(infracoes => infracoes.entradaInfracao >= dataInicio
                                  && infracoes.saidaInfracao <= dataFim
                                  && infracoes.MotoristaId == motoristaId)
                .ToList();

            return Ok(infracoesFiltradas);
        }


        [HttpPost("atualizarinfracoes")]
        public ActionResult<Infracoes> AtualizarInfracoes([FromBody] Infracoes infracoes)
        {
            if (infracoes == null)
                return BadRequest("Dados inválidos.");

            var editarInfracao = _context.infracoes.FirstOrDefault(j => j.infracaoId == infracoes.infracaoId);

            if (editarInfracao == null) return NotFound("Jornada não encontrada.");

            editarInfracao.velocidade = infracoes.velocidade;
            editarInfracao.reclamacao = infracoes.reclamacao;
            editarInfracao.multa = infracoes.multa;
            editarInfracao.pequenaMonta = infracoes.pequenaMonta;
            editarInfracao.grandeMonta = infracoes.grandeMonta;
            editarInfracao.entradaInfracao = infracoes.entradaInfracao;
            editarInfracao.saidaInfracao = infracoes.saidaInfracao;
            _context.SaveChanges();

            return Ok(editarInfracao);
        }
    }
}
