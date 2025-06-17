using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models.Entity;

[Table("Jornada")]
public class Jornada
{   
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public required DateOnly JornadaData { get; set; }
    
    [Required]
    [StringLength(250)]
    public string JornadaLocalidade { get; set; }
    
    [Required]
    [ForeignKey("MotoristaID")]
    public required Guid MotoristaID { get; set; }

    public virtual Motorista Motorista { get; set; }
    
    [Required]
    [StringLength(10)]
    public required string Placa { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Km { get; set; }

    }
