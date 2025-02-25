using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models;

[Table("Jornada")]
public class Jornada
{   [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid QuilometragemId { get; set; }
    
    [Required]
    public required DateOnly JornadaData { get; set; }
    
    [Required]
    public required DateTime JornadaHora { get; set; }
    
    [Required]
    [ForeignKey("MotoristaId")]
    public required Guid MotoristaID { get; set; }
    
    public virtual Motorista? Motorista { get; set; }
    
    [Required]
    [StringLength(10)]
    public required string Placa { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Km { get; set; }


}
