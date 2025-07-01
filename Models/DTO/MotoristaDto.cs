namespace Api.Models.DTO
{
    public class MotoristaDto
    {
        public Guid id { get; set; }
        public string DisplayName { get; set; }
        
        public string Telefone { get; set; }
        public int perfilAcesso { get; set; }
    }
}
