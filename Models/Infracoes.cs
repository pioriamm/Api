using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Infracoes
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid infracaoId { get; set; }

        [Required]
        [StringLength(250)]
        public string descricaoInfracao{ get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal pontuacao { get; set; }
    }
}
