using ServicoCepAtividade.Domain;
using ServicoCepAtividade.Repository;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServicoCepAtividade.Service
{
    public class CepService : ICepService
    {
        private readonly ICepRepository _repository;

        public CepService(ICepRepository repository)
        {
            _repository = repository;
        }

        public async Task<Cep> ConsultarCepAsync(string cep)
        {
            // Limpa formatação
            var cepLimpo = cep.Replace("-", "").Replace(" ", "");
            if (cepLimpo.Length != 8 || !long.TryParse(cepLimpo, out _))
                throw new ArgumentException("CEP inválido");

            var viaCep = await ConsultarViaCepAsync(cepLimpo);

            var cepEntity = new Cep
            {
                CepCode = viaCep.Cep,
                Logradouro = viaCep.Logradouro,
                Complemento = viaCep.Complemento,
                Bairro = viaCep.Bairro,
                Localidade = viaCep.Localidade,
                Uf = viaCep.Uf,
                Ibge = viaCep.Ibge,
                Gia = viaCep.Gia,
                Ddd = viaCep.Ddd,
                Siafi = viaCep.Siafi,
                DataConsulta = DateTime.Now
            };

            // Evita duplicata
            var existente = await _repository.GetCepByCodeAsync(cepEntity.CepCode);
            if (existente == null)
                await _repository.AddCepAsync(cepEntity);

            return cepEntity;
        }

        public async Task<List<Cep>> GetAllCepsAsync()
        {
            return await _repository.GetAllCepsAsync();
        }

        private async Task<ViaCepResponse> ConsultarViaCepAsync(string cep)
        {
            using var httpClient = new HttpClient();
            var url = $"https://viacep.com.br/ws/{cep}/json/";

            try
            {
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var viaCepResponse = JsonSerializer.Deserialize<ViaCepResponse>(json);

                if (viaCepResponse == null || viaCepResponse.Erro)
                    throw new ArgumentException("CEP não encontrado");

                return viaCepResponse;
            }
            catch
            {
                throw new Exception("Erro ao consultar Via CEP");
            }
        }
    }
}
