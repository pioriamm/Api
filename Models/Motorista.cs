using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Api.Context;
using Microsoft.VisualBasic;

namespace Api.Models;
using System.Collections.ObjectModel;

public class Motorista
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid MotoristaID { get; set; }
   
    [Required]
    [StringLength(100)]
    public string? DisplayName { get; set; }
    
    [Required]
    [StringLength(15)]
    public string? Telefone { get; set; }
    
    [JsonIgnore]
    public ICollection<Jornada> Jornadas { get; set; }
    
 
}