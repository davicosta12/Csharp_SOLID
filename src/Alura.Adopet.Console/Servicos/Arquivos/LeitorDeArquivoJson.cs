using System.Text.Json;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public class LeitorDeArquivoJson<T> : ILeitorDeArquivos<T>
    {
        private string caminhoArquivo;

        public LeitorDeArquivoJson(string caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }

        public IEnumerable<T> RealizaLeitura()
        {
            if (string.IsNullOrEmpty(caminhoArquivo))
            {
                return null;
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);
            var jsonDeserialize = JsonSerializer.Deserialize<IEnumerable<T>>(stream, options) ?? Enumerable.Empty<T>();
            return jsonDeserialize;
        }
    }
}