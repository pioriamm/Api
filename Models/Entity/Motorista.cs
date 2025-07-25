using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Api.Context;
using Microsoft.VisualBasic;

namespace Api.Models.Entity;

using System.Collections.ObjectModel;

public class Motorista
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required] 
    [StringLength(100)] 
    public string? DisplayName { get; set; }
    
    [Required]
    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.(com)$", ErrorMessage = "O e-mail deve conter '@' e terminar com '.com'.")]
    public string? Login { get; set; }

    [Required]
    [StringLength(9, MinimumLength = 1, ErrorMessage = "A senha deve ter no máximo 8 caracteres.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{1,9}$", ErrorMessage = "A senha deve conter pelo menos uma letra maiúscula, um número e um caractere especial.")]
    public string? PassWord { get; set; }
    
    [Required]
    [StringLength(15)]
    public string? Telefone { get; set; }

    [Required]   
    public DateOnly admissao { get; set; }

    [Required]
    public int perfilAcesso { get; set; }

    [Required]
    public string celularId { get; set; }

    [JsonIgnore]
    public ICollection<Jornada> Jornadas { get; set; }

    [JsonIgnore]
    public ICollection<Infracoes> Infracoes { get; set; }


}