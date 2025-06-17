using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models
{
    public class Infracoes
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid infracaoId { get; set; }
        [Required]
        public DateOnly entradaInfracao { get; set; }
        [Required]
        public DateOnly saidaInfracao { get; set; }
        [Required]       
        public bool velocidade { get; set; }
        [Required]
        public bool reclamacao { get; set; }
        [Required]
        public bool multa { get; set; }
        [Required]
        public bool pequenaMonta { get; set; }
        [Required]
        public bool grandeMonta { get; set; }

        [Required]
        public Guid MotoristaId { get; set; }

        [ForeignKey("MotoristaId")]
        public Motorista Motorista { get; set; }

    }
}
