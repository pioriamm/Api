namespace Api.Models
{
    public class MotoristaDto
    {
        public Guid id { get; set; }
        public string DisplayName { get; set; }
        
        public string Telefone { get; set; }
        public bool isAdim { get; set; }
    }
}
