namespace ServicoCepAtividade.Domain
{
    public class ViaCepResponse
    {
        public string Cep { get; set; } = null!;
        public string Logradouro { get; set; } = null!;
        public string? Complemento { get; set; }
        public string Bairro { get; set; } = null!;
        public string Localidade { get; set; } = null!;
        public string Uf { get; set; } = null!;
        public string Ibge { get; set; } = null!;
        public string? Gia { get; set; }
        public string Ddd { get; set; } = null!;
        public string Siafi { get; set; } = null!;
        public bool Erro { get; set; }
    }
}
