using Api.Context;
using Api.Models;
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
    }
}
