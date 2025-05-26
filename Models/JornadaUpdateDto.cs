namespace Api.Models
{
    public class JornadaUpdateDto
    {
        public Guid Id { get; set; }
        public DateOnly JornadaData { get; set; }
        public string JornadaLocalidade { get; set; }
        public Guid MotoristaID { get; set; }
        public string Placa { get; set; }
        public decimal Km { get; set; }
    }
}
