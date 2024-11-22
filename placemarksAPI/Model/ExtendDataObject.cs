namespace placemarksAPI.Model
{
    public class ExtendDataObject
    {
        public string? RuaCruzamento { get; set; }
        public string? Referencia { get; set; }
        public required string Bairro { get; set; }
        public required string Situacao { get; set; }
        public required string Cliente { get; set; }
        public string? Data { get; set; }
        public string? Coordenadas { get; set; }
        public string? GxMediaLinks { get; set; }
    }
}
