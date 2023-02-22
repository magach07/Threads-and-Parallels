using System.Text.Json;
using Threads.Models;

namespace Threads.ClientService
{
    public class CepService
    {
        public CepModel GetCep (string cep)
        {
            HttpClient client = new HttpClient();

            var response = client.GetAsync($"https://viacep.com.br/ws/{cep}/json/").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var cepResponse = JsonSerializer.Deserialize<CepModel>(content);

            return cepResponse;
        }
    }
}