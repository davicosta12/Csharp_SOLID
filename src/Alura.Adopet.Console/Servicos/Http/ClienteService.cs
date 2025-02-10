using System.Net.Http.Json;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Http
{
    public class ClienteService : IApiServices<Cliente>
    {
        private readonly HttpClient client;

        public ClienteService(HttpClient client)
        {
            this.client = client;
        }

        public async Task CreateAsync(Cliente cliente)
        {
            await client.PostAsJsonAsync("cliente/add", cliente);
        }

        public async Task<IEnumerable<Cliente>?> ListAsync()
        {
            HttpResponseMessage response = await client.GetAsync("cliente/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
        }
    }
}